using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using BeiDream.SbsAbp;

namespace BeiDream.SbsAbp.Localization
{
    public static class SbsAbpLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SbsAbpConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SbsAbpLocalizationConfigurer).GetAssembly(),
                        "BeiDream.SbsAbp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
