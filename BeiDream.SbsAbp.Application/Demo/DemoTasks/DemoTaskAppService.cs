using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using BeiDream.SbsAbp.Demo.DemoTasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public class DemoTaskAppService : SbsAbpAppServiceBase, IDemoTaskAppService
    {
        private readonly IRepository<DemoTask,Guid> _demoTaskRepository;
        public DemoTaskAppService(IRepository<DemoTask, Guid> demoTaskRepository)
        {
            _demoTaskRepository = demoTaskRepository;
        }
        public async Task<ListResultDto<DemoTaskListDto>> GetDemoTasks(GetDemoTasksInput input)
        {
            var query = _demoTaskRepository.GetAll();
            query = query.WhereIf(!input.Name.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Name))
                        .Where(p => p.IsPublish == input.IsPublish).OrderBy(input.Sorting);

            var demoTask = await query.ToListAsync();

            return new ListResultDto<DemoTaskListDto>(ObjectMapper.Map<List<DemoTaskListDto>>(demoTask));
        }

        public Task<PagedResultDto<DemoTaskListDto>> GetPagedDemoTasks(GetDemoTasksPagedInput input)
        {
            throw new NotImplementedException();
        }
        public Task<GetDemoTaskForEditOutput> GetDemoTaskForEdit(NullableIdDto<Guid> input)
        {
            throw new NotImplementedException();
        }
        public async Task CreateOrUpdateDemoTask(CreateOrUpdateDemoTaskInput input)
        {
            if (input.DemoTask.Id.HasValue)
            {
                await UpdateDemoTaskAsync(input);
            }
            else
            {
                await CreateDemoTaskAsync(input);
            }
        }
        public async Task CreateDemoTaskAsync(CreateOrUpdateDemoTaskInput input)
        {
            var entity = ObjectMapper.Map<DemoTask>(input.DemoTask);
            await _demoTaskRepository.InsertAsync(entity);
        }
        public async Task UpdateDemoTaskAsync(CreateOrUpdateDemoTaskInput input)
        {

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
