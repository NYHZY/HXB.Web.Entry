using Furion.DatabaseAccessor;
using HXB.Core.Entities;
using HXB.Core.Sys_Table;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.SysConfigure.SysTree
{
    public static class TreeTool
    {
        public static List<TreeNodeDataInfo> HandleTreeNodeData(ISqlRepository<MsSqlDbContextLocator> reposit, Sys_DynamicTree treeinfo, Sys_DynamicTreeNode treenode) {
            List<TreeNodeDataInfo> nodedatainfo = new List<TreeNodeDataInfo>();
            StringBuilder sql = new StringBuilder();
            sql.Append(MacroTool.MacroInit(treenode.nodesource));
            var dt = reposit.SqlQuery(sql.ToString());
            JArray ja = DataConvert.DataTableConvert(dt);
            foreach (JToken item in ja) {
                nodedatainfo.Add(
                    new TreeNodeDataInfo
                    {
                        id = Guid.NewGuid().ToString(),
                        text = item.Value<string>("label"),
                        leaf = item.Value<string>("leaf") == "0" ? true : false,
                        treeid = treeinfo.Id,
                        treenodeid = treenode.Id,
                        nodedata = item
                    });
            }
            return nodedatainfo;
        }
    }
}
