using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_Dictionary: BaseModel
    {
        /// <summary>
        /// 父ID 这里需要添加外键
        /// </summary>
        public int ParentId { get; set; }
        public string DictName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int? DictValue { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? DictValue1 { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? DictValue2 { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? DictValue3 { get; set; }
        public int? SystemId { get; set; }
    }
}
