﻿using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    [DependsOn(
        typeof(SbsAbpCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class SbsAbpEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpEntityFrameworkCoreModule).GetAssembly());
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpEfCore().AddDbContext<SbsAbpDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    SbsAbpDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    SbsAbpDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }
}
