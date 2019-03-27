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
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpApplicationModule).GetAssembly());
        }
    }
}
