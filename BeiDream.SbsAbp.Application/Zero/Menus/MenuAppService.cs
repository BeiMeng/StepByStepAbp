using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.GeneralTree;
using Abp.Runtime.Session;
using BeiDream.SbsAbp.Zero.Menus.Dto;
using Microsoft.EntityFrameworkCore;

namespace BeiDream.SbsAbp.Zero.Menus
{
    public class MenuAppService : SbsAbpAppServiceBase, IMenuAppService
    {
        private readonly IRepository<Menu, Guid> _menuRepository;
        private readonly IGeneralTreeManager<Menu, Guid> _menuTreeManager;
        public MenuAppService(IRepository<Menu, Guid> menuRepository, IGeneralTreeManager<Menu, Guid> menuTreeManager)
        {
            _menuRepository = menuRepository;
            _menuTreeManager = menuTreeManager;
        }
        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuTreeDto>> GetMenuTree()
        {
            return await GetMenuTree(null);
        }
        private async Task<List<MenuTreeDto>> GetMenuTree(Guid? partantId)
        {
            List<MenuTreeDto> menus = new List<MenuTreeDto>();
            var list =await _menuRepository.GetAll().Where(p => p.ParentId == partantId).ToListAsync();
            foreach (var item in list)
            {
                var menuTreeDto= ObjectMapper.Map<MenuTreeDto>(item);
                var items =await GetMenuTree(item.Id);
                foreach (var itemChild in items)
                {
                    menuTreeDto.Children.Add(itemChild);
                }
                menus.Add(menuTreeDto);
            }
            return menus;
        }
        /// <summary>
        /// 根据id获取一条菜单数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MenuDto> GetMenuForEdit(NullableIdDto<Guid> input)
        {
            var entity = await _menuRepository.GetAsync(input.Id.Value);
            return ObjectMapper.Map<MenuDto>(entity);
        }
        /// <summary>
        /// 新增或者编辑菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MenuDto> CreateOrUpdateMenuForOutput(MenuDto input)
        {
           
            if (input.Id.HasValue)
            {
                var menu =await _menuRepository.GetAsync(input.Id.Value);
                ObjectMapper.Map(input,menu);
                 await _menuTreeManager.UpdateAsync(menu);
                return ObjectMapper.Map<MenuDto>(menu);
            }
            else
            {
                var menu = ObjectMapper.Map<Menu>(input);
                await _menuTreeManager.CreateAsync(menu);
                await CurrentUnitOfWork.SaveChangesAsync();
                return ObjectMapper.Map<MenuDto>(menu);
            }

        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async  Task DeleteMenu(EntityDto<Guid> input)
        {
            await _menuTreeManager.DeleteAsync(input.Id);
        }
    }
}
