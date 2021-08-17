using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HXB.Web.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Inject()
                    .UseStartup<Startup>();
                }).ConfigureLogging((context, logger) =>
                {
                    logger.AddFilter("System", LogLevel.Warning);
                    logger.AddFilter("Microsoft", LogLevel.Warning);
                    logger.AddLog4Net("Log4net.config", true);

                });
    }
}
