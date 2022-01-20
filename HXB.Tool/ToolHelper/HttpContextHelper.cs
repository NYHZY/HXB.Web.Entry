using Furion;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.ToolHelper
{
    public static class HttpContextHelper
    {
        public static IHttpContextAccessor _accessor;

        /// <summary>
        /// HttpContext
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor.HttpContext;

        /// <summary>
        /// 装载HttpContext
        /// </summary>
        /// <param name="accessor"></param>
        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Request(string name)
        {
            return form(name) + query(name);
        }

        /// <summary>
        /// 获取Get请求参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string query(string name)
        {

            if (_accessor.HttpContext.Request.Query.Count != 0)
            {
                return _accessor.HttpContext.Request.Query[name];
            }
            return "";
        }
        /// <summary>
        /// 获取表单提交参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string form(string name)
        {

            if (_accessor.HttpContext.Request.HasFormContentType)
            {
                return _accessor.HttpContext.Request.Form[name];
            }
            return "";
        }
        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string heder(string name)
        {

            if (_accessor.HttpContext.Request.Headers.Count != 0)
            {
                return _accessor.HttpContext.Request.Headers[name];
            }
            return "";
        }
        /// <summary>
        /// 获取请求路径
        /// </summary>
        /// <returns></returns>
        public static string querypath()
        {

            if (_accessor.HttpContext.Request.Headers.Count != 0)
            {
                return _accessor.HttpContext.Request.Path;
            }
            return "";
        }
        /// <summary>
        /// 获取Cookies参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Cookies(string name)
        {

            if (_accessor.HttpContext.Request.Cookies.Count != 0)
            {
                return _accessor.HttpContext.Request.Cookies[name];
            }
            return "";
        }
        /// <summary>
        /// 获取系统Id
        /// </summary>
        /// <returns></returns>
        public static decimal GetSystemId()
        {
            decimal systemId = 0;
            string SystemMethod = App.Configuration["SystemModule:SystemMethod"];
            //客户端传参
            if (SystemMethod.Trim().Equals("Client", StringComparison.OrdinalIgnoreCase))
            {
                systemId = Convert.ToDecimal(Request("sys_pt_id"));
            }
            else  //服务端传参
            {
                systemId = Convert.ToDecimal(App.Configuration["SystemModule:SystemId"]);

            }
            return systemId;
        }
        /// <summary>
        /// 获取文件参数
        /// </summary>
        /// <returns></returns>
        public static IFormFileCollection Files()
        {
            return _accessor.HttpContext.Request.Form.Files;
        }

    }
}
