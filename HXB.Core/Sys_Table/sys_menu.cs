using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_Menu : BaseModel
    {
        /// <summary>
        /// 父id
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 系统id
        /// </summary>
        public int? SystemId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
    }
}
