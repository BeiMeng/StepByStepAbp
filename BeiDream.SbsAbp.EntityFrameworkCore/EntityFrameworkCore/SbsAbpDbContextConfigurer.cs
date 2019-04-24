using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    /// <summary>
    /// 备注：数据库进行切换时，请重新执行命令生成迁移代码
    /// </summary>
    public class SbsAbpDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SbsAbpDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(5, 6, 33), ServerType.MySql); // replace with your Server Version and Type
            });
        }

        public static void Configure(DbContextOptionsBuilder<SbsAbpDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(5, 6, 33), ServerType.MySql); // replace with your Server Version and Type
            });
        }
    }
}
