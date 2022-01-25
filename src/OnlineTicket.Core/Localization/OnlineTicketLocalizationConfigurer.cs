using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OnlineTicket.Localization
{
    public static class OnlineTicketLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OnlineTicketConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OnlineTicketLocalizationConfigurer).GetAssembly(),
                        "OnlineTicket.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
