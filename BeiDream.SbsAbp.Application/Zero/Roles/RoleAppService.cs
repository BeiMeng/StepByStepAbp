using Abp.Application.Services.Dto;
using Abp.Authorization;
using BeiDream.SbsAbp.Zero.Authorization;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using BeiDream.SbsAbp.Zero.Roles.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Roles
{
    [AbpAuthorize(ZeroPermissionNames.ZeroPages_Roles)]
    public class RoleAppService : SbsAbpAppServiceBase, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        public RoleAppService(
            RoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        /// <summary>
        /// 获取全部角色
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<RoleListDto>> GetRoles()
        {
            var query = _roleManager.Roles;

            var roles = await query.ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }
        /// <summary>
        /// 根据Id获取待编辑的角色数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_MenusTree_Create, ZeroPermissionNames.ZeroPages_Roles_Edit)]
        public async Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input)
        {
            var grantedPermissions = new Permission[0];
            RoleEditDto roleEditDto;

            if (input.Id.HasValue) //Editing existing role?
            {
                var role = await _roleManager.GetRoleByIdAsync(input.Id.Value);
                grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
                roleEditDto = ObjectMapper.Map<RoleEditDto>(role);
            }
            else
            {
                roleEditDto = new RoleEditDto();
            }

            return new GetRoleForEditOutput
            {
                item = roleEditDto,
                GrantedPermissionNames = grantedPermissions.Where(p=>p.Children.Count==0).Select(p => p.Name).ToList()//只选择叶节点，父节点自动选中
            };
        }
        /// <summary>
        /// 新增或编辑角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<EntityDto> CreateOrUpdateRole(CreateOrUpdateRoleInput input)
        {
            if (input.Item.Id.HasValue)
            {
              return  await UpdateRoleAsync(input);
            }
            else
            {
               return await CreateRoleAsync(input);
            }
        }

        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Roles_Edit)]
        protected virtual async Task<EntityDto> UpdateRoleAsync(CreateOrUpdateRoleInput input)
        {
            //Debug.Assert(input.Role.Id != null, "input.Role.Id should be set.");

            var role = await _roleManager.GetRoleByIdAsync(input.Item.Id.Value);
            role.DisplayName = input.Item.DisplayName;
            role.IsDefault = input.Item.IsDefault;
            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
            return new EntityDto(role.Id);
        }

        [AbpAuthorize(ZeroPermissionNames.ZeroPages_MenusTree_Create)]
        protected virtual async Task<EntityDto> CreateRoleAsync(CreateOrUpdateRoleInput input)
        {
            var role = new Role(AbpSession.TenantId, input.Item.DisplayName) { IsDefault = input.Item.IsDefault };
            CheckErrors(await _roleManager.CreateAsync(role));
            await CurrentUnitOfWork.SaveChangesAsync(); //It's done to get Id of the role.
            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
            return new EntityDto(role.Id);
        }

        private async Task UpdateGrantedPermissionsAsync(Role role, List<string> grantedPermissionNames)
        {
            var grantedPermissions = PermissionManager.GetPermissionsFromNamesByValidating(grantedPermissionNames);
            //todo 判断系统配置权限不能删除
            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }





        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Roles_Delete)]
        public async Task DeleteRole(EntityDto input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            var users = await UserManager.GetUsersInRoleAsync(role.Name);
            foreach (var user in users)
            {
                CheckErrors(await UserManager.RemoveFromRoleAsync(user, role.Name));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }
    }
}
