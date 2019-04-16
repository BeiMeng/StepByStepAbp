using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Common.AppSetting
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return GetThemeSettings();
        }
        private IEnumerable<SettingDefinition> GetThemeSettings()
        {
            return new[] {
                new SettingDefinition(AppSettingNames.Theme.ShowPageTab, "true", isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.Theme.ShowHeaderMenus, "true", isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.Theme.MaxTabCount, "15", isVisibleToClients: true),
            };
        }
    }
}
