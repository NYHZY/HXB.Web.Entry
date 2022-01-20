using Furion.DatabaseAccessor;
using HXB.Core.Sys_Table;
using HXB.EntityFramework.Core.DbContextLocators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.EntityFramework.Core.DbContexts
{
    [AppDbContext("MsSqlConnectionString", DbProvider.SqlServer)]
    public class MsSqlDbContext : AppDbContext<MsSqlDbContext,MsSqlDbContextLocator>
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
        }
        public DbSet<Sys_User> sys_user { get; set; }
    }
}
