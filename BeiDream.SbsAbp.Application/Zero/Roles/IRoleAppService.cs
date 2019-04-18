using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BeiDream.SbsAbp.Zero.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Roles
{
    public  interface IRoleAppService : IApplicationService
    {
        Task<ListResultDto<RoleListDto>> GetRoles();
        Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input);
        Task<EntityDto> CreateOrUpdateRole(CreateOrUpdateRoleInput input);
        Task DeleteRole(EntityDto input);
    }
}
