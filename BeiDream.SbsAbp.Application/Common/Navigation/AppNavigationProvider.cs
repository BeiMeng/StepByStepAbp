using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using BeiDream.SbsAbp.Demo.Authorization;
using BeiDream.SbsAbp.Demo.DemoTasks;
using BeiDream.SbsAbp.Zero.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.SbsAbp.Demo.Navigation
{
    public class AppNavigationProvider : NavigationProvider
    {
        private readonly IRepository<Menu, Guid> _menuRepository;
        public AppNavigationProvider(IRepository<Menu, Guid> menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public const string MenuName = "App";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("主菜单"));

            var list = _menuRepository.GetAllList();
            var menus = GetMenuItemDefinitions(null);

            //var list = _menuRepository.GetAll().Where(p => p.ParentId == null);
            //foreach (var item in list)
            //{
            //    var menuItemDefinition = new MenuItemDefinition(
            //        name:item.Name,
            //        displayName:L(item.DisplayName),
            //        url:item.Url,
            //        icon:item.IconClass,
            //        order:item.Order,
            //        permissionDependency: new SimplePermissionDependency(item.PermissionName),
            //        customData:new {
            //            item.Group,item.IsHome,item.Default,item.NotClose
            //        }                    
            //     );
            //    var children = _menuRepository.GetAll().Where(p => p.ParentId == item.Id);
            //    foreach (var itemChild in children)
            //    {
            //        var menuItemDefinitionChild = new MenuItemDefinition(
            //            name: itemChild.Name,
            //            displayName: L(itemChild.DisplayName),
            //            url: itemChild.Url,
            //            icon: itemChild.IconClass,
            //            order: itemChild.Order,
            //            permissionDependency: new SimplePermissionDependency(itemChild.PermissionName),
            //            customData: new
            //            {
            //                itemChild.Group,
            //                itemChild.IsHome,
            //                itemChild.Default,
            //                itemChild.NotClose
            //            }
            //         );
            //    }
            //}
        }
        [UnitOfWork]
        public List<MenuItemDefinition> GetMenuItemDefinitions(Guid? partantId)
        {
            List<MenuItemDefinition> menus = new List<MenuItemDefinition>();
            var list = _menuRepository.GetAll().Where(p => p.ParentId == partantId).ToList();
            foreach (var item in list)
            {
                var menuItemDefinition = new MenuItemDefinition(
                    name: item.Name,
                    displayName: L(item.DisplayName),
                    url: item.Url,
                    icon: item.IconClass,
                    order: item.Order,
                    permissionDependency: new SimplePermissionDependency(item.PermissionName),
                    customData: new
                    {
                        item.Group,
                        item.IsHome,
                        item.Default,
                        item.NotClose
                    }
                 );
                var items=GetMenuItemDefinitions(item.Id);
                foreach (var itemChild in items)
                {
                    menuItemDefinition.AddItem(itemChild);
                }
                menus.Add(menuItemDefinition);
            }
            return menus;
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SbsAbpConsts.LocalizationSourceName);
        }
    }
}
