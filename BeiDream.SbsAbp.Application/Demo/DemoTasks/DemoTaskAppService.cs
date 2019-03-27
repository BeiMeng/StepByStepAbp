using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public class DemoTaskAppService : SbsAbpAppServiceBase, IDemoTaskAppService
    {
        public void dyAppTest()
        {
            var m=10;
        }
    }
}
