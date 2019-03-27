using Abp.Modules;
using Abp.Reflection.Extensions;
using BeiDream.SbsAbp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Web
{
    [DependsOn(
        typeof(SbsAbpEntityFrameworkCoreModule))]
    public class SbsAbpWebHostModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpWebHostModule).GetAssembly());
        }
    }
}
