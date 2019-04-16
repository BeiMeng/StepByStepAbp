using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using BeiDream.SbsAbp.Common.AppSetting;
using BeiDream.SbsAbp.Zero.ThemeSetting.Dto;

namespace BeiDream.SbsAbp.Zero.ThemeSetting
{
    public class ThemeSettingAppService : SbsAbpAppServiceBase, IThemeSettingAppService
    {
        protected ISettingManager SettingManager;
        public ThemeSettingAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }
        /// <summary>
        /// 设置UI主题
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task SettingTheme(ThemeDto input)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.Theme.ShowPageTab, input.ShowPageTab.ToString());
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.Theme.ShowHeaderMenus, input.ShowHeaderMenus.ToString());
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.Theme.MaxTabCount, input.MaxTabCount.ToString());
        }
    }
}
