using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using chilli.software.common.Model.Const;
using chilli.software.web.Infrastructure;

namespace chilli.software.web.Localization.Configuration
{
    public static class Localization
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", isDefault: true));
            localizationConfiguration.Languages.Add(new LanguageInfo("pl", "Polski"));
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AppConst.AppName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(WebModule).GetAssembly(),
                        $"{AppConst.AppName}.Localization"
                    )
                )
            );
        }
    }
}