using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Entities
{
    public class ChangeData
    {
        /// <summary>
        /// 数据源动态界面id
        /// </summary>
        public int pageid { get; set; }
        /// <summary>
        /// 增加的数据
        /// </summary>
        public List<JObject> addlist { get; set; }
        /// <summary>
        /// 修改的数据
        /// </summary>
        public List<JObject> udplist { get; set; }
    }
}
