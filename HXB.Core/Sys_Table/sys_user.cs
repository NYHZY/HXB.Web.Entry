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
    public class Sys_User : BaseModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [MaxLength(50)]
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        public string PassWord { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        public string RealName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(100)]
        public string NickName { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [MaxLength(18)]
        public string IdNo { get; set; }
        /// <summary>
        /// 名族
        /// </summary>
        public int? Nationality { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(150)]
        public string Address { get; set; }
    }
}
