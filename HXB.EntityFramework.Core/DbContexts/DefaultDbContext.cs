using Furion.DatabaseAccessor;
using HXB.EntityFramework.Core.DbContextLocators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.EntityFramework.Core.DbContexts
{
    //默认是Mysql数据库上下文
    [AppDbContext("MySqlConnectionString", DbProvider.Sqlite)]
    public class DefaultDbContext:AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}
