using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    [Table("sys_redisconfig")]
    public class sys_redisconfig
    {
        public int parentid { get; set; }
        public string modelname { get; set; }
        public int timeout { get; set; }
    }
}
