using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    public class SbsAbpDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SbsAbpDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SbsAbpDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
