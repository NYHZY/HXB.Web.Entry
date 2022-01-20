using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_DynamicTree: BaseModel
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// 树名称
        /// </summary>
        public string TreeName { get; set; }
        /// <summary>
        /// 配置
        /// </summary>
        public string OtherAtt { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public int IsexPand { get; set; }
        /// <summary>
        /// 是否显示复选框
        /// </summary>
        public int ShowCheckbox { get; set; }
        /// <summary>
        /// 系统id
        /// </summary>
        public int SystemId { get; set; }
    }
}
