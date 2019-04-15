using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BeiDream.SbsAbp.Zero.Menus.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Menus
{
    public interface IMenuAppService : IApplicationService
    {
        Task<List<MenuTreeDto>> GetMenuTree();
        Task<MenuDto> GetMenuForEdit(NullableIdDto<Guid> input);
        Task<MenuDto> CreateOrUpdateMenuForOutput(MenuDto input);
        Task DeleteMenu(EntityDto<Guid> input);
    }
}
