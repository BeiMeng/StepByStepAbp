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
        Task<MenuDto> CreateOrUpdateMenuForOutput(MenuDto input);
        Task DeleteMenu(EntityDto<Guid> input);
    }
}
