using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class sys_dictionary: BaseModel
    {
        /// <summary>
        /// 父ID 这里需要添加外键
        /// </summary>
        public int parentid { get; set; }
        public string dictname { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int? dictvalue { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? dictvalue1 { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? dictvalue2 { get; set; }
        /// <summary>
        /// 扩展值
        /// </summary>
        public int? dictvalue3 { get; set; }
        public int? systemid { get; set; }
    }
}
