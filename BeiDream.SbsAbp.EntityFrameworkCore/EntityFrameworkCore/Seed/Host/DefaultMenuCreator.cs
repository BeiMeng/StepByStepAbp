using BeiDream.SbsAbp.Zero.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.SbsAbp.EntityFrameworkCore.Seed.Host
{
    public class DefaultMenuCreator
    {
        private readonly SbsAbpDbContext _context;

        public DefaultMenuCreator(SbsAbpDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateMenus();
        }

        private void CreateMenus()
        {
            var dashboardMenu = _context.Menus.IgnoreQueryFilters().FirstOrDefault(e => e.Name == "dashboard");
            if (dashboardMenu == null)
            {
                dashboardMenu = new Menu
                {
                    Name = "dashboard",
                    DisplayName = "首页",
                    Url ="/",
                    IconClass = "icon-diamond",
                    IsHome =true,
                    NotClose=true,
                    Order=1,
                    PermissionName= "AppPages",
                };
                _context.Menus.Add(dashboardMenu);
                _context.SaveChanges();
                /* Add desired features to the standard edition, if wanted... */
            }
            var zeroMenu= _context.Menus.IgnoreQueryFilters().FirstOrDefault(e => e.Name == "zero");
            if (zeroMenu == null)
            {
                zeroMenu = new Menu
                {
                    Name = "zero",
                    Default=true,
                    DisplayName = "系统管理",
                    IconClass = "icon-diamond",
                    Order = 1,
                    PermissionName = "ZeroPages",
                };
                _context.Menus.Add(zeroMenu);
                _context.SaveChanges();

                var menusTree = new Menu
                {
                    Name = "menusTree",
                    Default=true,
                    DisplayName = "菜单管理",
                    Url= "/app/zero/menusTree",
                    IconClass = "icon-diamond",
                    Order = 1,
                    ParentId = zeroMenu.Id,
                    PermissionName = "ZeroPages.MenusTree",
                };
                _context.Menus.Add(menusTree);
                _context.SaveChanges();
                /* Add desired features to the standard edition, if wanted... */
            }
        }
    }
}
