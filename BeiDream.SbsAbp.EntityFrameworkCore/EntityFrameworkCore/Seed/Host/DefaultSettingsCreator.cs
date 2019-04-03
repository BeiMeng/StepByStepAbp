using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;

namespace BeiDream.SbsAbp.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly SbsAbpDbContext _context;

        public DefaultSettingsCreator(SbsAbpDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var tenantId = SbsAbpConsts.MultiTenancyEnabled ? null : (int?)1;
            // Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com", tenantId);
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer", tenantId);

            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "zh-Hans", tenantId);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
