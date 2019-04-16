using Abp.Application.Navigation;
using Abp.AutoMapper;
using Abp.GeneralTree;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Configuration.Startup;
using Abp.Zero;
using Abp.Zero.Configuration;
using BeiDream.SbsAbp.Localization;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using BeiDream.SbsAbp.Zero.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using BeiDream.SbsAbp.Navigation;
using BeiDream.SbsAbp.Common.AppSetting;

namespace BeiDream.SbsAbp
{
    [DependsOn(
        typeof(GeneralTreeModule),
        typeof(AbpZeroCoreModule),
        typeof(AbpAutoMapperModule))]
    public class SbsAbpCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            SbsAbpLocalizationConfigurer.Configure(Configuration.Localization);

            //添加Theme Setting
            Configuration.Settings.Providers.Add<AppSettingProvider>();

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = SbsAbpConsts.MultiTenancyEnabled;

            // Configure roles
            //AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //使用自定义的菜单管理
            Configuration.ReplaceService<INavigationManager, BeiDreamNavigationManager>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpCoreModule).GetAssembly());
        }
    }
}
