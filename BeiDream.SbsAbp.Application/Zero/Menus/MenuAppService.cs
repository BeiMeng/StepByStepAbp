using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.GeneralTree;
using BeiDream.SbsAbp.Zero.Menus.Dto;

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

        public async  Task DeleteMenu(EntityDto<Guid> input)
        {
            await _menuTreeManager.DeleteAsync(input.Id);
        }
    }
}
