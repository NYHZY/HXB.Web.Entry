using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    [Table("sys_login_info")]
    public class sys_login_info:BaseModel
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime login_date { get; set; }
        public string login_ip { get; set; }
        public DateTime logindate { get; set; }
    }
}
