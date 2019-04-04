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

            var demo = pages.CreateChildPermission(ZeroPermissionNames.ZeroPages, L("系统管理"));

            var users = demo.CreateChildPermission(ZeroPermissionNames.ZeroPages_Users, L("用户管理"));

            var roles = demo.CreateChildPermission(ZeroPermissionNames.ZeroPages_Roles, L("角色管理"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SbsAbpConsts.LocalizationSourceName);
        }
    }
}
