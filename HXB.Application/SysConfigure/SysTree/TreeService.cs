using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using HXB.Core.Entities;
using HXB.Core.Sys_Table;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Tool;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.SysConfigure.SysTree
{
    public class TreeService: IDynamicApiController
    {
        private readonly ISqlRepository<MsSqlDbContextLocator> _reposit;
        private readonly ILogger<TreeService> _logger;
        public TreeService(ISqlRepository<MsSqlDbContextLocator> reposit, ILogger<TreeService> logger) {
            _reposit = reposit;
            _logger = logger;
        }
        public RESTfulres<object> GetTree(int treeid) {
            var res = new RESTfulres<object>();
            try { 
                var treecfg= _reposit.SqlQuery<Sys_DynamicTree>("select * from sys_dynamictree where id=@id",new { id=treeid}).FirstOrDefault();
                res = RESTfulres<object>.Success("获取成功");
                res.Data = treecfg;
            }
            catch (Exception ex)
            {
                res = RESTfulres<object>.Erro(ex.Message);
                _logger.LogError(ex.Message, ex);
            }
            return res;
        }
        [Route("/api/tree/tree-data")]
        [HttpPost]
        public RESTfulres<object> GetTreeData(int treeid,int treenodeid)
        {
            var res = new RESTfulres<object>();
            StringBuilder sql = new StringBuilder();
            List<TreeNodeDataInfo> info = new List<TreeNodeDataInfo>();
            sql.Append("select * from sys_dynamictreenode where ");
            if (treenodeid == 0)
            {
                sql.Append("treeid=@treeid and parentid is null order by rowno");
            }
            else
            {
                sql.Append("parentid=@treenodeid order by rowno");
            }
            try
            {
                var treecfg = _reposit.SqlQuery<Sys_DynamicTree>("select * from sys_dynamictree where id=@id", new { id = treeid }).FirstOrDefault();
                var nodecfg = _reposit.SqlQuery<Sys_DynamicTreeNode>(sql.ToString(),new { treeid =treeid, treenodeid = treenodeid });
                foreach (var item in nodecfg) {
                    info.AddRange(TreeTool.HandleTreeNodeData(_reposit, treecfg, item));
                }
                res = RESTfulres<object>.Success("获取成功");
                res.Data = info;
            }
            catch (Exception ex)
            {
                res = RESTfulres<object>.Erro(ex.Message);
                _logger.LogError(ex.Message, ex);
            }
            sql.Clear();
            return res;
        }
    }
}
