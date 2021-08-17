using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.Authorization.Model
{
    public class UserInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        public string realname { get; set; }
        public string nickname { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public int sex { get; set; }

    }
}
