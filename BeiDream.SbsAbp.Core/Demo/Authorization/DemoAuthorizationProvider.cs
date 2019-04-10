using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Demo.Authorization
{

    public class DemoAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(SbsAbpConsts.AppPages) ?? context.CreatePermission(SbsAbpConsts.AppPages, L("后台系统"));

            var demo = pages.CreateChildPermission(DemoPermissionNames.DemoPages, L("测试模块"));

            var demoTasks = demo.CreateChildPermission(DemoPermissionNames.DemoPages_DemoTasks, L("测试任务"));
            demoTasks.CreateChildPermission(DemoPermissionNames.DemoPages_DemoTasks_Create, L("新增任务"));
            demoTasks.CreateChildPermission(DemoPermissionNames.DemoPages_DemoTasks_Edit, L("编辑任务"));
            demoTasks.CreateChildPermission(DemoPermissionNames.DemoPages_DemoTasks_Delete, L("删除任务"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SbsAbpConsts.LocalizationSourceName);
        }
    }
}
