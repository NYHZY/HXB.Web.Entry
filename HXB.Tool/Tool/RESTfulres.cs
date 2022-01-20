using Furion.UnifyResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Tool
{
    public class RESTfulres<T>: RESTfulResult<T>
    {
        public string ResMsg { get; set; }
        public int Count { get; set; }
        public static RESTfulres<T> Success(string msg=null) {
            var res = new RESTfulres<T>();
            res.StatusCode = 200;
            res.Succeeded = true;
            res.ResMsg = msg;
            return res;
        }
        public static RESTfulres<T> Erro(string msg,int StatusCode = 500)
        {
            var res = new RESTfulres<T>();
            res.StatusCode = StatusCode;
            res.Succeeded = false;
            res.ResMsg = msg;
            return res;
        }
    }
}
