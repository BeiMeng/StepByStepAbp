using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BeiDream.SbsAbp.Demo.DemoTasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public class DemoTaskAppService : SbsAbpAppServiceBase, IDemoTaskAppService
    {
        public Task<ListResultDto<DemoTaskListDto>> GetDemoTasks(GetDemoTasksInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<DemoTaskListDto>> GetPagedDemoTasks(GetDemoTasksPagedInput input)
        {
            throw new NotImplementedException();
        }
        public Task<GetDemoTaskForEditOutput> GetDemoTaskForEdit(NullableIdDto<Guid> input)
        {
            throw new NotImplementedException();
        }
        public Task CreateOrUpdateDemoTask(CreateOrUpdateDemoTaskInput input)
        {
            throw new NotImplementedException();
        }

        public Task<CreatedOrUpdatedOutput> CreateOrUpdateDemoTaskForOutput(CreateOrUpdateDemoTaskInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDemoTask(EntityDto<Guid> input)
        {
            throw new NotImplementedException();
        }




    }
}
