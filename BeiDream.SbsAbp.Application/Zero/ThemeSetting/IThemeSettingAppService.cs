using Abp.Application.Services;
using BeiDream.SbsAbp.Zero.ThemeSetting.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.ThemeSetting
{
    public interface IThemeSettingAppService : IApplicationService
    {
        Task SettingTheme(ThemeDto input);
    }
}
