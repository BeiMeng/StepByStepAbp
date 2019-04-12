using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Localization;
using BeiDream.SbsAbp.Demo.Authorization;
using BeiDream.SbsAbp.Demo.DemoTasks;
using BeiDream.SbsAbp.Zero.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Demo.Navigation
{
    public class AppNavigationProvider : NavigationProvider
    {
        //private readonly IRepository<Menu, Guid> _menuRepository;
        //public AppNavigationProvider(IRepository<Menu, Guid> menuRepository)
        //{
        //    _menuRepository = menuRepository;
        //}
        public const string MenuName = "App";

        public override void SetNavigation(INavigationProviderContext context)
        {
            //var d = _menuRepository.GetAllList();
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("主菜单"));

            //menu
                //.AddItem(new MenuItemDefinition(
                //        AppPageNames.DemoTasks,
                //        L("测试任务"),
                //        url: "/app/demo/demoTask",
                //        icon: "icon-diamond",
                //        permissionDependency: new SimplePermissionDependency(DemoPermissionNames.DemoPages_DemoTasks)
                //    )
                //);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SbsAbpConsts.LocalizationSourceName);
        }
    }
}
