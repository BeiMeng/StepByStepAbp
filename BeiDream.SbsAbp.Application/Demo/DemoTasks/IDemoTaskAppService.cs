using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BeiDream.SbsAbp.Demo.DemoTasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Demo.DemoTasks
{
    public interface IDemoTaskAppService : IApplicationService
    {
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="input">查询参数</param>
        /// <returns></returns>
        Task<ListResultDto<DemoTaskListDto>> GetDemoTasks(GetDemoTasksInput input);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="input">带分页条件查询参数</param>
        /// <returns></returns>
        Task<PagedResultDto<DemoTaskListDto>> GetPagedDemoTasks(GetDemoTasksPagedInput input);
        /// <summary>
        /// 获取编辑的单条数据
        /// </summary>
        /// <param name="input">数据的主键Id</param>
        /// <returns></returns>
        Task<GetDemoTaskForEditOutput> GetDemoTaskForEdit(NullableIdDto<Guid> input);
        /// <summary>
        /// 新增或者更新单条数据
        /// </summary>
        /// <param name="input">数据对象</param>
        /// <returns></returns>
        Task CreateOrUpdateDemoTask(CreateOrUpdateDemoTaskInput input);
        /// <summary>
        /// 带返回值的 新增或更新
        /// </summary>
        /// <param name="input">数据对象</param>
        /// <returns></returns>
        Task<CreatedOrUpdatedOutput> CreateOrUpdateDemoTaskForOutput(CreateOrUpdateDemoTaskInput input);
        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="input">数据主键Id</param>
        /// <returns></returns>
        Task DeleteDemoTask(EntityDto<Guid> input);
    }
}
