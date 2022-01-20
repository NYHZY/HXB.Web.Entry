using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Entities
{
    public class TreeNodeDataInfo
    {
        public TreeNodeDataInfo() {
            this.leaf = false;
        }
        public string id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 子节点信息
        /// </summary>
        public bool leaf;

        /// <summary>
        /// treeId
        /// </summary>
        public int treeid { get; set; }

        /// <summary>
        /// treenodeId
        /// </summary>
        public int treenodeid { get; set; }
        /// <summary>
        /// 获取的数据
        /// </summary>
        public object nodedata { get; set; }
    }
}
