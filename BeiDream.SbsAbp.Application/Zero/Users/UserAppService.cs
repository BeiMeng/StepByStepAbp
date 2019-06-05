using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Linq.Extensions;
using BeiDream.SbsAbp.Zero.Authorization;
using BeiDream.SbsAbp.Zero.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Abp.Zero.Configuration;
using Abp.Configuration;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using Abp.Runtime.Session;
using Abp.UI;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using System.Collections.ObjectModel;
using Abp.Authorization.Users;
using Abp.Notifications;

namespace BeiDream.SbsAbp.Zero.Users
{
    [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users)]
    public class UserAppService : SbsAbpAppServiceBase, IUserAppService
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly RoleManager _roleManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        public UserAppService(RoleManager roleManager,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            INotificationPublisher notificationPublisher,
            IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _passwordValidators = passwordValidators;
            _roleManager = roleManager;
            _notificationPublisher = notificationPublisher;
        }
        /// <summary>
        /// 获取分页的用户数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input)
        {
            var query = UserManager.Users
                .WhereIf(input.Role.HasValue, u => u.Roles.Any(r => r.RoleId == input.Role.Value))
                .WhereIf(input.OnlyLockedUsers, u => u.LockoutEndDateUtc.HasValue && u.LockoutEndDateUtc.Value > DateTime.UtcNow)
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );

            var userCount = await query.CountAsync();

            var users = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);

            return new PagedResultDto<UserListDto>(
                userCount,
                userListDtos
                );
        }

        /// <summary>
        /// 获取待编辑的用户数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Create, ZeroPermissionNames.ZeroPages_Users_Edit)]
        public async Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input)
        {
            var output = new GetUserForEditOutput
            {
                Roles = new List<AssignedUserRoleDto>()
            };

            if (!input.Id.HasValue)
            {
                var defaultRoles = await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync();
                //Creating a new user
                output.Item = new UserEditDto
                {
                    IsActive = true,
                    IsLockoutEnabled = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.UserLockOut.IsEnabled)
                };
                output.Roles= ObjectMapper.Map<List<AssignedUserRoleDto>>(defaultRoles);

            }
            else
            {
                //Editing an existing user
                var user = await UserManager.GetUserByIdAsync(input.Id.Value);

                output.Item = ObjectMapper.Map<UserEditDto>(user);
                var userRoleDtos = await _roleManager.Roles
                    .OrderBy(r => r.DisplayName)
                    .ToListAsync();
                foreach (var userRoleDto in userRoleDtos)
                {
                    if (await UserManager.IsInRoleAsync(user, userRoleDto.Name))
                    {
                        output.Roles.Add(ObjectMapper.Map<AssignedUserRoleDto>(userRoleDto));
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// 新增或者修改用户数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<EntityDto<long>> CreateOrUpdateUser(CreateOrUpdateUserInput input)
        {
            if (input.Item.Id.HasValue)
            {
               return await UpdateUserAsync(input);
            }
            else
            {
               return await CreateUserAsync(input);
            }
        }
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Edit)]
        protected virtual async Task<EntityDto<long>> UpdateUserAsync(CreateOrUpdateUserInput input)
        {
            Debug.Assert(input.Item.Id != null, "input.User.Id should be set.");

            var user = await UserManager.FindByIdAsync(input.Item.Id.Value.ToString());

            //Update user properties
            ObjectMapper.Map(input.Item, user); //Passwords is not mapped (see mapping configuration)

            if (input.SetRandomPassword)
            {
                var randomPassword = await UserManager.CreateRandomPassword();
                user.Password = _passwordHasher.HashPassword(user, randomPassword);
                input.Item.Password = randomPassword;
            }
            else if (!input.Item.Password.IsNullOrEmpty())
            {
                await UserManager.InitializeOptionsAsync(AbpSession.TenantId);
                CheckErrors(await UserManager.ChangePasswordAsync(user, input.Item.Password));
            }

            CheckErrors(await UserManager.UpdateAsync(user));

            //Update roles
            CheckErrors(await UserManager.SetRoles(user, input.AssignedRoleNames));

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData("有更新用户信息操作!"),
                severity: NotificationSeverity.Info,
                userIds: new[] { user.ToUserIdentifier() }
                );

            return new EntityDto<long>(user.Id);
        }

        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Create)]
        protected virtual async Task<EntityDto<long>> CreateUserAsync(CreateOrUpdateUserInput input)
        {
            var user = ObjectMapper.Map<User>(input.Item); //Passwords is not mapped (see mapping configuration)
            user.TenantId = AbpSession.TenantId;

            //Set password
            if (input.SetRandomPassword)
            {
                var randomPassword = await UserManager.CreateRandomPassword();
                user.Password = _passwordHasher.HashPassword(user, randomPassword);
                input.Item.Password = randomPassword;
            }
            else if (!input.Item.Password.IsNullOrEmpty())
            {
                await UserManager.InitializeOptionsAsync(AbpSession.TenantId);
                foreach (var validator in _passwordValidators)
                {
                    CheckErrors(await validator.ValidateAsync(UserManager, user, input.Item.Password));
                }

                user.Password = _passwordHasher.HashPassword(user, input.Item.Password);
            }

            //Assign roles
            user.Roles = new Collection<UserRole>();
            foreach (var roleName in input.AssignedRoleNames)
            {
                var role = await _roleManager.GetRoleByNameAsync(roleName);
                user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
            }

            CheckErrors(await UserManager.CreateAsync(user));
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new user's Id.

            return new EntityDto<long>(user.Id);


        }
        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Delete)]
        public async Task DeleteUser(EntityDto<long> input)
        {
            if (input.Id == AbpSession.GetUserId())
            {
                throw new UserFriendlyException(L("你不能删除当前登陆的用户！"));
            }

            var user = await UserManager.GetUserByIdAsync(input.Id);
            CheckErrors(await UserManager.DeleteAsync(user));
        }


        /// <summary>
        /// 获取用户拥有的权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Permission)]
        public async Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(NullableIdDto<long> input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id.Value);
            var grantedPermissions = await UserManager.GetGrantedPermissionsAsync(user);

            return new GetUserPermissionsForEditOutput
            {
                GrantedPermissionNames = grantedPermissions.Where(p=>p.Children.Count==0).Select(p => p.Name).ToList()
            };
        }
        /// <summary>
        /// 更新用户的权限信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ZeroPermissionNames.ZeroPages_Users_Permission)]
        public async Task UpdateUserPermissions(UpdateUserPermissionsInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            var grantedPermissions = PermissionManager.GetPermissionsFromNamesByValidating(input.GrantedPermissionNames);
            //todo 判断系统配置权限不能删除
            await UserManager.SetGrantedPermissionsAsync(user, grantedPermissions);
        }
    }
}
