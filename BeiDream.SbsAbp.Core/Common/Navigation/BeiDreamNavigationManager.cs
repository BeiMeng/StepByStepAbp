using Abp;
using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using BeiDream.SbsAbp.Zero.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.SbsAbp.Navigation
{
    public class BeiDreamNavigationManager : INavigationManager, ISingletonDependency
    {
        public const string MenuName = "App";
        private readonly IRepository<Menu, Guid> _menuRepository;
        private IDictionary<string, MenuDefinition> menus;
        public IDictionary<string, MenuDefinition> Menus
        {
            get
            {
                var menu = new MenuDefinition(MenuName, new FixedLocalizableString("主菜单"));
                var menus = GetMenuItemDefinitions(null);
                foreach (var menuChild in menus)
                {
                    menu.AddItem(menuChild);
                }
                var Menus = new Dictionary<string, MenuDefinition>
                        {
                            {MenuName, menu}
                        };
                return Menus;
            }
            private set
            {
                menus = value;
            }
        }

        public MenuDefinition MainMenu
        {
            get { return Menus["MainMenu"]; }
        }
        public BeiDreamNavigationManager(IRepository<Menu, Guid> menuRepository)
        {
            _menuRepository = menuRepository;
        }
        [UnitOfWork]
        public virtual List<MenuItemDefinition> GetMenuItemDefinitions(Guid? partantId)
        {
            List<MenuItemDefinition> menus = new List<MenuItemDefinition>();
            //todo 一次性取出，并添加缓存
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
                        item.Id,
                        item.PermissionName,
                        item.Group,
                        item.IsHome,
                        item.Default,
                        item.NotClose
                    }
                 );
                var items = GetMenuItemDefinitions(item.Id);
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
