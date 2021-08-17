using Furion;
using HXB.Tool.Middleware;
using HXB.Tool.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool
{
    [AppStartup(1000)]
    public class ToolStartup: AppStartup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //redis缓存
            //连接字符串
            //string _connectionString = App.Configuration["Redis:Default:Connection"];
            ////实例名称
            //string _instanceName = App.Configuration["Redis:Default:InstanceName"];
            ////默认数据库 
            //int _defaultDB = int.Parse(App.Configuration["Redis:Default:DefaultDB"]?? "0");
            //services.AddSingleton(new RedisHelper(_connectionString, _instanceName, _defaultDB));


            //初始化 RedisHelper
            RedisHelper.Initialization(new CSRedis.CSRedisClient(App.Configuration["Redis:Default:Connection"]));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //使用请求拦截中间件
            app.UseHttpContextMiddleware();
        }
    }
}
