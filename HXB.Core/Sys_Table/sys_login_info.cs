using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    [Table("sys_login_info")]
    public class Sys_Login_Info : BaseModel
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime Login_Date { get; set; }
        public string Login_Ip { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
