using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
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

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpApplicationModule).GetAssembly());
        }
    }
}
