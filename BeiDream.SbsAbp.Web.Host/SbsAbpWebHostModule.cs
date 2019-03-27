using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BeiDream.SbsAbp.Configuration;
using BeiDream.SbsAbp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Web
{
    [DependsOn(
        typeof(SbsAbpApplicationModule),
        typeof(SbsAbpEntityFrameworkCoreModule),
         typeof(AbpAspNetCoreModule))]
    public class SbsAbpWebHostModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SbsAbpWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            //Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SbsAbpConsts.ConnectionStringName);

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SbsAbpApplicationModule).GetAssembly()
                );
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpWebHostModule).GetAssembly());
        }
    }
}
