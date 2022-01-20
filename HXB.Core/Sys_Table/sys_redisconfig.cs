using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    [Table("sys_redisconfig")]
    public class Sys_RedisConfig
    {
        public int ParentId { get; set; }
        public string ModelName { get; set; }
        public int TimeOut { get; set; }
    }
}
