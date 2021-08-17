using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpContextMiddleware>();
        }
    }
}
