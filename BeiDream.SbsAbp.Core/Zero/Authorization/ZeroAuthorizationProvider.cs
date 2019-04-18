using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Authorization
{

    public class ZeroAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(SbsAbpConsts.AppPages) ?? context.CreatePermission(SbsAbpConsts.AppPages, L("后台系统"));

            var zero = pages.CreateChildPermission(ZeroPermissionNames.ZeroPages, L("系统管理"));

            var users = zero.CreateChildPermission(ZeroPermissionNames.ZeroPages_Users, L("用户管理"));

            var roles = zero.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles, L("角色管理"));
            roles.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles_Create, L("新增角色"));
            roles.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles_Edit, L("编辑角色"));
            roles.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles_Delete, L("删除角色"));
            roles.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles_Permission, L("权限设置"));

            var menuTree = zero.CreateChildPermission(ZeroPermissionNames.ZeroPages_MenusTree, L("菜单管理"));
            menuTree.CreateChildPermission(ZeroPermissionNames.ZeroPages_MenusTree_Create, L("新增菜单"));
            menuTree.CreateChildPermission(ZeroPermissionNames.ZeroPages_MenusTree_Edit, L("编辑菜单"));
            menuTree.CreateChildPermission(ZeroPermissionNames.ZeroPages_MenusTree_Delete, L("删除菜单"));

            zero.CreateChildPermission(ZeroPermissionNames.ZeroPages_ThemeSetting, L("主题设置"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SbsAbpConsts.LocalizationSourceName);
        }
    }
}
