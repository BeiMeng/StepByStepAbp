using Abp.Auditing;
using Abp.Configuration;
using BeiDream.SbsAbp.Common.AppSetting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Sessions.Dto
{
    public class SessionAppService : SbsAbpAppServiceBase, ISessionAppService
    {
        protected ISettingManager SettingManager;
        public SessionAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }
        /// <summary>
        /// 获取当前登录用户的相关信息
        /// </summary>
        /// <returns></returns>
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput();

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
                output.Theme = new ThemeLoginInfoDto
                {
                    ShowPageTab=Convert.ToBoolean(await GetSettingValueAsync(AppSettingNames.Theme.ShowPageTab)),
                    ShowHeaderMenus = Convert.ToBoolean(await GetSettingValueAsync(AppSettingNames.Theme.ShowHeaderMenus)),
                    MaxTabCount = Convert.ToInt32(await GetSettingValueAsync(AppSettingNames.Theme.MaxTabCount))
                };
            }

            return output;
        }
        private async Task<string> GetSettingValueAsync(string settingName)
        {
            return await SettingManager.GetSettingValueAsync(settingName);
        }
    }
}
