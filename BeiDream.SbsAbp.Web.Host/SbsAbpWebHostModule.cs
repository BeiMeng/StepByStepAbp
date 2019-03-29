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
            //从appsettings.json获取数据库链接字符串并配置为默认链接
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SbsAbpConsts.ConnectionStringName);

            //将application层 动态生成 webapi
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
