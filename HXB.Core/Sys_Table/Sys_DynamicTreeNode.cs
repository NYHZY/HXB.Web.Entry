using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_DynamicTreeNode:BaseModel
    {
        /// <summary>
        /// 父id
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 树id
        /// </summary>
        public int treeid { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string nodename { get; set; }
        /// <summary>
        /// 节点数据源
        /// </summary>
        public string nodesource { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int rowno { get; set; }
        /// <summary>
        /// 配置
        /// </summary>
        public int otheratt { get; set; }
    }
}
