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
    [AppDbContext("PostgreSQLConnectionString", DbProvider.Npgsql)]
    public class PostgreSqlDbContext : AppDbContext<PostgreSqlDbContext, PostgreSqlDbContextLocator>
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options)
        {
        }
    }
}
