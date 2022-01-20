using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Entities
{
    public class OnLineUserInfo
    {
       
        public int id { get; set; }
        public string realname { get; set; }
        public string loginname { get; set; }
        public string nickname { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public string token { get; set; }
    }
}
