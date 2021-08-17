using Furion;
using Furion.DatabaseAccessor;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.EntityFramework.Core.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.EntityFramework.Core
{
    [AppStartup(600)]
    public class DBStartup: AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                //默认Mysql数据库
                options.AddDbPool<DefaultDbContext>(DbProvider.MySql);
                
                options.AddDbPool<MsSqlDbContext, MsSqlDbContextLocator>(DbProvider.SqlServer);

                options.AddDbPool<OralceDbContext, OracleDbContextLocator>(DbProvider.Oracle);

                options.AddDbPool<PostgreSqlDbContext, PostgreSqlDbContextLocator>(DbProvider.Npgsql);
            }, "HXB.Database.Migrations");
        }
    }
}
