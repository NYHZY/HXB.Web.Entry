using Furion;
using HXB.Tool.ToolModel.MiddlewareModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Middleware
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpContextMiddleware> _logger;
        public HttpContextMiddleware(RequestDelegate next, ILogger<HttpContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            //判断是否开启验证
            string isauthorization = App.Configuration["isauthorization"];
            var api = new ApiRequestModel
            {
                HttpType = context.Request.Method,
                Query = context.Request.QueryString.Value,
                RequestUrl = context.Request.Path,
                RequestIP = context.Request.Host.Value,
                Header = context.Request.Headers["token"]
            };
            try {
                if (isauthorization.StartsWith("true")) { 
                    //判断配置的接口是否需要验证 to do
                }
            }
            catch (Exception)
            {

            }
            await _next(context);//交个下一个中间件
        }
    }
}
