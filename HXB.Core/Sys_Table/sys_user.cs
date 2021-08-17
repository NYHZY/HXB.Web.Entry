using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    [Table("sys_user")]
    public class sys_user: BaseModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [MaxLength(50)]
        public string loginname { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        public string password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        public string realname { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(100)]
        public string nickname { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? age { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public int? sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [MaxLength(18)]
        public string idno { get; set; }
        /// <summary>
        /// 名族
        /// </summary>
        public int? nationality { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(20)]
        public string phone { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? birthdate { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(150)]
        public string address { get; set; }
    }
}
