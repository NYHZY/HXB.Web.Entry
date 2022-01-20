using Furion.DatabaseAccessor;
using HXB.Core.Entities;
using HXB.Core.Sys_Table;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Tool;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.SysConfigure.SysPage
{
    public static class PageTool
    {
        public static Sys_DynamicPage GetPageInfo(int pageid,ISqlRepository<MsSqlDbContextLocator> reposit) {
            return reposit.SqlQuery<Sys_DynamicPage>(@"select t.* from sys_dynamicpage t where t.id=@pageid", new { pageid = pageid }).FirstOrDefault();
        }
        /// <summary>
        /// 获取动态表单各列的配置
        /// </summary>
        /// <param name="pageid"></param>
        /// <param name="reposit"></param>
        /// <returns></returns>
        public static List<Sys_DynamicCol> GetColCfg(int pageid, ISqlRepository<MsSqlDbContextLocator> reposit) {
            return reposit.SqlQuery<Sys_DynamicCol>(@"select * from sys_dynamiccol where refid=@pageid order by rowvalue,columnvalue", new { pageid =pageid }).ToList();
        }
        /// <summary>
        /// 获取动态界面主键
        /// </summary>
        /// <param name="pagcol"></param>
        /// <returns></returns>
        public static Sys_DynamicCol GetColKey(List<Sys_DynamicCol> pagcol)
        {
            //获取主键名称
            var pkList = pagcol.Where(p => p.PrimaryKey == 1);
            if (pkList.Count() == 0)
            {
                throw new Exception("主键未定义！");
            }
            if (pkList.Count() > 1)
            {
                throw new Exception("主键未定义过多！");
            }
            return pkList.First();
        }
        /// <summary>
        /// 获取动态表格的按钮配置
        /// </summary>
        /// <param name="pageid"></param>
        /// <param name="reposit"></param>
        /// <returns></returns>
        public static List<Sys_DynamicBtn> GetBtnCfg(int pageid, ISqlRepository<MsSqlDbContextLocator> reposit)
        {
            return reposit.SqlQuery<Sys_DynamicBtn>(@"select * from sys_dynamicbtn where parentid=@pageid", new { pageid = pageid }).ToList();
        }
        public static void SavePageData(ISqlRepository<MsSqlDbContextLocator> reposit,Dictionary<string, ValueDbtype> data,string sql) {
           if (data.Count > 0) {
                int index = 0;
                DbParameter[] array = new DbParameter[data.Count];
                foreach (var item in data)
                {
                    SqlParameter sqlparams = new SqlParameter();
                    sqlparams.Value = item.Value.val;
                    sqlparams.ParameterName = item.Key;
                    sqlparams.DbType = item.Value.dbtype;
                    array[index++] = sqlparams;
                }
                reposit.SqlScalar(sql, array);
            }
            
        }
        public static void InitCol(ISqlRepository<MsSqlDbContextLocator> reposit, List<Sys_DynamicCol> colInfo, Sys_DynamicPage pageinfo) {
            //处理列属性
            foreach (var it in colInfo)
            {

                //处理默认值
                if (!string.IsNullOrEmpty(it.DefaultValue)) it.DefaultValue = MacroTool.MacroInit(it.DefaultValue);
                //处理下拉数据源
                if (!string.IsNullOrEmpty(it.SelectData)) InitColListArray(reposit, it, pageinfo);

            }
        }
        /// <summary>
        /// 处理下拉列表数据信息
        /// </summary>
        /// <param name="reposit"></param>
        /// <param name="col"></param>
        /// <param name="pageInfo"></param>
        public static void InitColListArray(ISqlRepository<MsSqlDbContextLocator> reposit, Sys_DynamicCol col, Sys_DynamicPage pageInfo) {
            if (col.SelectData.StartsWith("sql:", StringComparison.CurrentCultureIgnoreCase))
            {
                string _sourceSql = MacroTool.MacroInit(col.SelectData.Substring(4));
                try
                {
                    var dt = reposit.SqlQuery(_sourceSql);
                    var dir = new List<Dictionary<string, object>>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var d = new Dictionary<string, object>
                                            {
                                                { "value", dt.Rows[i][0]},
                                                { "display", dt.Rows[i][1] }
                                            };
                        dir.Add(d);
                    }
                    col.SelectData = JsonConvert.SerializeObject(dir);
                }
                catch (Exception ex)
                {
                    throw new Exception(col.ColumnName + "处理Sql：list失败:[" + ex.Message + "]");
                }
            }
        }
        public static void ExecObj(int pageid) { 
        }
    }
}
