using System.Configuration;

namespace Ninja.FileUtil.Configuration.Simple
{
    public sealed class Settings : ConfigurationSection
    {
        public char Delimeter { get; set; }
        
        public const string SectionXPath = "FileUtil/SimpleMode";
        private const string ProviderSettingKey = "Provider";
        private const string ParserSettingKey = "Parser";

        public Settings()
        {
            Properties.Add(new ConfigurationProperty(ProviderSettingKey, typeof(ParserSettings), null));
            Properties.Add(new ConfigurationProperty(ProviderSettingKey, typeof(ProviderSettings), null));
        }

        public static ProviderSettings GetSection()
        {
            return (ProviderSettings)ConfigurationManager.GetSection(SectionXPath);
        }


        public IConfiguration ParserSettings
        {
            get { return (ParserSettings)this[ParserSettingKey]; }
            set { this[ParserSettingKey] = value; }
        }


        public IProviderSettings ProviderSettings
        {
            get { return (ProviderSettings)this[ProviderSettingKey]; }
            set { this[ProviderSettingKey] = value; }
        }
    }
}