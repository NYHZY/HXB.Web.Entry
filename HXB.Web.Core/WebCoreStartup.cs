using Furion;
using HXB.Tool.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HXB.Web.Core
{
    [AppStartup(999)]
    public class WebCoreStartup: AppStartup
    {
       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers().AddInjectWithUnifyResult();
            //注册动态api
            services.AddDynamicApiControllers();
            //注册友好异常处理
            services.AddFriendlyException();
            //设置跨域
            services.AddCorsAccessor();
            services.AddResponseCompression(options =>
             {
                 options.EnableForHttps = false;
                 options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                 {
                    "text/html; charset=utf-8",
                    "application/xhtml+xml",
                    "application/atom+xml",
                    "image/svg+xml"
                });
             });
        //配置全局序列化
        services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpContextMiddleware();
            app.UseCorsAccessor();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //使用swagger
            app.UseInject(string.Empty);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
