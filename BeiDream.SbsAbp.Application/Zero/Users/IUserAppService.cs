using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BeiDream.SbsAbp.Zero.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input);
        Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input);
        Task<EntityDto<long>> CreateOrUpdateUser(CreateOrUpdateUserInput input);
        Task DeleteUser(EntityDto<long> input);

        Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(NullableIdDto<long> input);
        Task UpdateUserPermissions(UpdateUserPermissionsInput input);
    }
}
