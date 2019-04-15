using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BeiDream.SbsAbp.Demo.Authorization;
using BeiDream.SbsAbp.Zero;
using BeiDream.SbsAbp.Zero.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp
{
    [DependsOn(
    typeof(SbsAbpCoreModule)
    )]
    public class SbsAbpApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //添加权限数据
            Configuration.Authorization.Providers.Add<DemoAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ZeroAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(DemoDtoMapper.CreateMappings);
            //Zero
            Configuration.Modules.AbpAutoMapper().Configurators.Add(ZeroDtoMapper.CreateMappings);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpApplicationModule).GetAssembly());
        }
    }
}
