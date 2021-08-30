using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.ApplicationModel.SysConfigure.SysMenu
{
    public class sys_menu
    {
        public int id { get; set; }
        public int parentid { get; set; }
        public int systemid { get; set; }
        public string menuname { get; set; }
        public string icon { get; set; }
        public int linktype { get; set; }
        public string linktext { get; set; }
        public string linkconfig { get; set; }
        public int sort { get; set; }
        public int leaf { get; set; }
    }
}
