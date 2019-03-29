using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp
{
    [DependsOn(
        typeof(AbpAutoMapperModule))]
    public class SbsAbpCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpCoreModule).GetAssembly());
        }
    }
}
