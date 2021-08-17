using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.ToolModel.MiddlewareModel
{
    internal class ApiRequestModel
    {
        public string HttpType { get; set; }
        public string Query { get; set; }
        public string RequestIP { get; set; }
        public string RequestUrl { get; set; }
        public string Header { get; set; }
    }
}
