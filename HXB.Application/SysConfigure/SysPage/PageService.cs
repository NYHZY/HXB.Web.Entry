using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.UnifyResult;
using HXB.Tool.Tool;
using HXB.Core.Sys_Table;
using HXB.EntityFramework.Core.DbContextLocators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HXB.Core.Entities;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace HXB.Application.SysConfigure.SysPage
{
    public class PageService: IDynamicApiController
    {
        private readonly ISqlRepository<MsSqlDbContextLocator> _reposit;
        private readonly ILogger<PageService> _logger;
        //使用完此变量记得clear（）一下
        StringBuilder sql = new StringBuilder();
        public PageService(ISqlRepository<MsSqlDbContextLocator> reposit,ILogger<PageService> logger)
        {
            _reposit = reposit;
            _logger = logger;
        }
        [HttpPost]
        public RESTfulres<object> GetPage([FromForm]int pageid) {
            //Sys_DynamicPage
            var res = new RESTfulres<object>();
            var pageinfo = new Sys_DynamicPage();
            try
            {
                pageinfo = PageTool.GetPageInfo(pageid, _reposit);
                if (pageinfo != null) {
                    //屏蔽特殊字段值
                    pageinfo.DataSourceSql = "";
                    //获取表格列的配置信息
                    pageinfo.ColInfo = PageTool.GetColCfg(pageid, _reposit);
                    //获取表格按钮配置信息
                    pageinfo.ButtonInfo = PageTool.GetBtnCfg(pageid, _reposit);
                    //处理默认属性
                    PageTool.InitCol(_reposit, pageinfo.ColInfo, pageinfo);
                }
                res = RESTfulres<object>.Success("获取成功");
                res.Data = pageinfo;

            }
            catch(Exception ex) {
                res = RESTfulres<object>.Erro(ex.Message);
                _logger.LogError(ex.Message, ex);
            }
            return res;
        }
        [Route("/api/page/page-data")]
        [HttpPost]
        public RESTfulres<object> GetPageData(int pageid,int pagesize=20,int pageindex=1)
        {
            var res = new RESTfulres<object>();
            var pageinfo = new Sys_DynamicPage();
            try
            {
                pageinfo = PageTool.GetPageInfo(pageid, _reposit);
                //此处要做一个sql转换操作
                pageinfo.DataSourceSql = MacroTool.MacroInit(pageinfo.DataSourceSql);
                sql.AppendFormat("select * from (select t.*,0 orderno from ({0}) t) res order by res.orderno offset (({1}-1)*{2}) rows fetch next {3} rows only", pageinfo.DataSourceSql, pageindex,pagesize,pagesize);
                var data = _reposit.SqlQuery(sql.ToString());
                int cnt = _reposit.SqlQuery<int>(pageinfo.DataSourceSql).Count;
                res = RESTfulres<object>.Success("获取成功");
                res.Data = data;
                res.Count = cnt;
                sql.Clear();
            }
            catch(Exception ex)
            {
                res = RESTfulres<object>.Erro(ex.Message);
                _logger.LogError(ex.Message,ex);
            }
            return res;
        }
        public RESTfulres<object> GetPageField(int pageid)
        {
            var res = new RESTfulres<object>();
            using (var transaction = _reposit.Database.BeginTransaction()) {
                try
                {
                    var pageinfo = PageTool.GetPageInfo(pageid, _reposit);
                    sql.AppendFormat("select * from ({0}) t where 1=2", pageinfo.DataSourceSql);
                    var columndata = _reposit.SqlQuery(sql.ToString());
                    var oldcolumn = _reposit.SqlQuery("select columnname from sys_dynamiccol where refid=@pageid and reftype=1", new { pageid = pageid });
                    foreach (DataColumn dc in columndata.Columns) {
                        if (oldcolumn.Rows.Count != 0 && oldcolumn.Select("columnname = '" + dc.ColumnName.ToLower() + "'").Count() > 0) continue;
                        int rowvalue=0, columntype=0, columnwidth=0, datatype=0;
                        rowvalue++;
                        switch (dc.DataType.Name.ToUpper()) { 
                            case "NUMBER":
                            case "INTEGER":
                            case "FLOAT":
                            case "INT":
                            case "INT32":
                            case "INT16":
                            case "INT64":
                            case "UINT":
                            case "UINT32":
                            case "UINT16":
                            case "UINT64":
                            case "DECIMAL":
                            case "LONG":
                            case "ULONG":
                            case "SINGLE":
                            case "DOUBLE":
                            case "USHORT":
                                columntype = 1;//文本编辑框类型
                                columnwidth = 8;//列宽
                                datatype = 1;//数字类型
                                break;
                            case "DATE":
                            case "DATETIME":
                            case "TIMESTAMP":
                            case "DATETIMEOFFSET":
                                columntype = 2;//日期编辑框类型
                                columnwidth = 12;//列宽
                                datatype = 2;//日期类型
                                break;
                            default:
                                columntype = 1;//文本编辑框类型
                                columnwidth = 12;//列宽
                                datatype = 3;//字符串类型
                                break;
                        }
                        _reposit.SqlScalar(@"insert into sys_dynamiccol (refid,columnname,columntext,isrequired,columnwidth,columntype,datatype,rowvalue,reftype)
                                             values(@pageid,@columnname,@columntext,@isrequired,@columnwidth,@columntype,@datatype,@rowvalue,@reftype)",
                                             new {
                                                 pageid = pageid,
                                                 columnname= dc.ColumnName.ToLower(),
                                                 columntext = dc.ColumnName.ToLower(),
                                                 isrequired= dc.AllowDBNull ? 0 : 1,
                                                 columnwidth = columnwidth,
                                                 columntype= columntype,
                                                 datatype= datatype,
                                                 rowvalue= rowvalue,
                                                 reftype=1
                                             });
                    }
                    sql.Clear();
                    transaction.Commit();
                    res = RESTfulres<object>.Success("获取成功");
                }
                catch(Exception ex)
                {
                    res = RESTfulres<object>.Erro(ex.Message);
                    _logger.LogError(ex.Message);
                    transaction.Rollback();
                }
            }
            return res;
        }
        [Route("/api/page/save-page-data")]
        [HttpPost]
        public RESTfulres<object> SavePageData(string data)
        {
            var res = new RESTfulres<object>();
            using (var transaction = _reposit.Database.BeginTransaction()) {
                try
                {
                    var changedata = JsonConvert.DeserializeObject<ChangeData>(data);
                    if (changedata.pageid == 0) throw new Exception("pageid不能为空");
                    //获取动态界面信息
                    var pageinfo = PageTool.GetPageInfo(changedata.pageid, _reposit);
                    pageinfo.ColInfo = PageTool.GetColCfg(changedata.pageid, _reposit);
                    string pkcol = PageTool.GetColKey(pageinfo.ColInfo).ColumnName;
                    
                    //获取动态界面执行对象 to do...

                    if (changedata.addlist.Count != 0) {
                        foreach (var item in changedata.addlist) {
                            var field = new List<string>();
                            var field_parms = new List<string>();
                            Dictionary<string, ValueDbtype> dicdata = new Dictionary<string, ValueDbtype>();
                            foreach (var col in pageinfo.ColInfo.Where(o => o.IsBind == 1)) {
                                field.Add(col.ColumnName);
                                field_parms.Add("@" + col.ColumnName);
                                var _val = DataConvert.GetJsonPropValue<object>(col.ColumnName, col.DataType, item);
                                dicdata.Add(col.ColumnName, DataConvert.GetDbTypedValue(col.DataType, _val, col.ColumnName));
                            }
                            //新增前事件 to do
                            //method
                            
                            //存储新增数据
                            sql.AppendFormat(@"insert into {0}({1})values({2})",pageinfo.DataSourceTable,string.Join(',',field), string.Join(',', field_parms));
                            PageTool.SavePageData(_reposit, dicdata, sql.ToString());
                            sql.Clear();

                            //新增后事件 to do
                            //method
                        }
                    }
                    if (changedata.udplist.Count != 0) {
                        
                        foreach (var item in changedata.udplist) {
                            var field = new List<string>();
                            Dictionary<string, ValueDbtype> dicdata = new Dictionary<string, ValueDbtype>();
                            foreach (var col in pageinfo.ColInfo.Where(o => o.IsBind == 1))
                            {
                                if(!pkcol.Equals(col.ColumnName, StringComparison.OrdinalIgnoreCase)) field.Add(col.ColumnName+"=@"+ col.ColumnName);
                                var _val = DataConvert.GetJsonPropValue<object>(col.ColumnName, col.DataType, item);
                                dicdata.Add(col.ColumnName, DataConvert.GetDbTypedValue(col.DataType, _val, col.ColumnName));
                            }
                            //修改前事件 to do
                            //method
                            sql.AppendFormat(@"update {0} set {1} where {2}", pageinfo.DataSourceTable, string.Join(',', field), pkcol + "=@"+ pkcol);
                            //sql.AppendFormat(@"update {0} set pagename=@pagename,createdtime=@createdtime,parentid=@parentid where {1}", pageinfo.DataSourceTable, pkcol + "=@"+ pkcol);
                            PageTool.SavePageData(_reposit, dicdata, sql.ToString());
                            sql.Clear();
                            //_reposit.SqlScalar(sql.ToString(), dicdata);

                            //修改后事件 to do
                            //method
                        }
                    }
                    sql.Clear();
                    transaction.Commit();
                    res = RESTfulres<object>.Success("保存成功");
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    transaction.Rollback();
                    res = RESTfulres<object>.Erro(ex.Message);
                }
            }
            return res;
        }
        [Route("/api/page/del-page-data")]
        public RESTfulres<object> DelPageData(int pageid,int[] ids)
        {
            var data = new RESTfulres<object>();
            try
            {
            }
            catch
            {

            }
            return data;
        }
    }
}
