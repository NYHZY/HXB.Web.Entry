using Furion;
using HXB.Tool.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                endpoints.MapControllers();
            });
        }
    }
}
