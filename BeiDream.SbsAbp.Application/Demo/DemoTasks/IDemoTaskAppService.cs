using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public interface IDemoTaskAppService : IApplicationService
    {
        void dyAppTest();
    }
}
