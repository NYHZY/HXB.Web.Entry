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
    [AppDbContext("OracleConnectionString", DbProvider.Oracle)]
    public class OralceDbContext : AppDbContext<OralceDbContext, OracleDbContextLocator>
    {
        public OralceDbContext(DbContextOptions<OralceDbContext> options) : base(options)
        {
        }
    }
}
