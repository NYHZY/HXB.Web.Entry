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
    public class BaseModel: Entity
    {
        public BaseModel()
        {
            Isvalid = 1;
        }
        
        public int Isvalid { get; set; }
        
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        public int CreatedUserid { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Required]
        public int UpdatedUserid { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remarks { get; set; }
    }
}
