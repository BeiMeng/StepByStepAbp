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
using Abp.Authorization;
using BeiDream.SbsAbp.Demo.Authorization;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public class DemoTaskAppService : SbsAbpAppServiceBase, IDemoTaskAppService
    {
        private readonly IRepository<DemoTask,Guid> _demoTaskRepository;
        public DemoTaskAppService(IRepository<DemoTask, Guid> demoTaskRepository)
        {
            _demoTaskRepository = demoTaskRepository;
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="input">查询参数</param>
        /// <returns></returns>
        [AbpAuthorize(DemoPermissionNames.DemoPages_DemoTasks)]
        public async Task<ListResultDto<DemoTaskListDto>> GetDemoTasks(GetDemoTasksInput input)
        {
            var query = _demoTaskRepository.GetAll();
            query = query.WhereIf(!input.Name.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Name))
                        .WhereIf(input.IsPublish.HasValue, p => p.IsPublish == input.IsPublish).OrderBy(input.Sorting);

            var demoTask = await query.ToListAsync();

            return new ListResultDto<DemoTaskListDto>(ObjectMapper.Map<List<DemoTaskListDto>>(demoTask));
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="input">带分页条件查询参数</param>
        /// <returns></returns>
        public async Task<PagedResultDto<DemoTaskListDto>> GetPagedDemoTasks(GetDemoTasksPagedInput input)
        {
            var query = _demoTaskRepository.GetAll();
            query = query.WhereIf(!input.Name.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Name))
                        .Where(p => p.IsPublish == input.IsPublish).OrderBy(input.Sorting);

            var count = await query.CountAsync();

            var items = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var listDtos = ObjectMapper.Map<List<DemoTaskListDto>>(items);

            return new PagedResultDto<DemoTaskListDto>(
                            count,
                            listDtos
                        );
        }
        /// <summary>
        /// 获取编辑的单条数据
        /// </summary>
        /// <param name="input">数据的主键Id</param>
        /// <returns></returns>
        public async Task<GetDemoTaskForEditOutput> GetDemoTaskForEdit(NullableIdDto<Guid> input)
        {
            var entity = await _demoTaskRepository.GetAsync(input.Id.Value);
            return new GetDemoTaskForEditOutput {
                            DemoTask= ObjectMapper.Map<DemoTaskEditDto>(entity)
                        };
        }
        /// <summary>
        /// 新增或者更新单条数据
        /// </summary>
        /// <param name="input">数据对象</param>
        /// <returns></returns>
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
        private async Task CreateDemoTaskAsync(CreateOrUpdateDemoTaskInput input)
        {
            var entity = ObjectMapper.Map<DemoTask>(input.DemoTask);
            await _demoTaskRepository.InsertAsync(entity);
        }
        private async Task UpdateDemoTaskAsync(CreateOrUpdateDemoTaskInput input)
        {
            var entity =await _demoTaskRepository.GetAsync(input.DemoTask.Id.Value);
            ObjectMapper.Map(input.DemoTask, entity);
        }
        /// <summary>
        /// 带返回值的 新增或更新
        /// </summary>
        /// <param name="input">数据对象</param>
        /// <returns></returns>
        public async Task<CreatedOrUpdatedOutput> CreateOrUpdateDemoTaskForOutput(CreateOrUpdateDemoTaskInput input)
        {
            if (input.DemoTask.Id.HasValue)
            {
               return await UpdateDemoTaskForOutputAsync(input);
            }
            else
            {
               return await CreateDemoTaskForOutputAsync(input);
            }
        }
        private async Task<CreatedOrUpdatedOutput> CreateDemoTaskForOutputAsync(CreateOrUpdateDemoTaskInput input)
        {
            var entity = ObjectMapper.Map<DemoTask>(input.DemoTask);
            await _demoTaskRepository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new CreatedOrUpdatedOutput() { Id=entity.Id};
        }
        private async Task<CreatedOrUpdatedOutput> UpdateDemoTaskForOutputAsync(CreateOrUpdateDemoTaskInput input)
        {
            var entity = await _demoTaskRepository.GetAsync(input.DemoTask.Id.Value);
            ObjectMapper.Map(input.DemoTask, entity);
            return new CreatedOrUpdatedOutput() { Id = entity.Id };
        }
        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="input">数据主键Id</param>
        /// <returns></returns>
        public async Task DeleteDemoTask(EntityDto<Guid> input)
        {
            await _demoTaskRepository.DeleteAsync(input.Id);
        }

    }
}
