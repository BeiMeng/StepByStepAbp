using Abp.BackgroundJobs;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Users
{
    public class TestJob : BackgroundJob<TestJobArgs>, ITransientDependency
    {
        public override void Execute(TestJobArgs args)
        {
            Logger.Debug(args.Name+"："+args.Age);
        }
    }
}
