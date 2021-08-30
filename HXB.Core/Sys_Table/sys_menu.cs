using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class sys_menu: BaseModel
    {
        /// <summary>
        /// 父id
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// 系统id
        /// </summary>
        public int? systemid { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }
    }
}
