using BeiDream.SbsAbp.Configuration;
using BeiDream.SbsAbp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SbsAbpDbContextFactory : IDesignTimeDbContextFactory<SbsAbpDbContext>
    {
        public SbsAbpDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SbsAbpDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: false);

            SbsAbpDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SbsAbpConsts.ConnectionStringName));

            var dbContext = new SbsAbpDbContext(builder.Options);
            //dbContext.SuppressAutoSetTenantId = true;
            return dbContext;
        }
    }
}
