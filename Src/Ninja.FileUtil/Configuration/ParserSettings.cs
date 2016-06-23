using System.Configuration;

namespace Ninja.FileUtil.Configuration
{
    public class ParserSettings : ConfigurationElement, IParserSettings
    {
        private const string DelimiterKey = "delimiter";
        private const string HeaderKey = "header";
        private const string FooterKey = "footer";
        private const string DataKey = "data";

        public const char DelimiterDefault= '|';
        public const string HeaderDefault = "H";
        public const string FooterDefault = "F";
        public const string DataDefault = "D";

        [ConfigurationProperty(DelimiterKey, IsRequired = false, DefaultValue = DelimiterDefault)]
        public char Delimiter
        {
            get
            {
                return ((char)(this[DelimiterKey]));
            }
            set
            {
                this[DelimiterKey] = value;
            }
        }

        [ConfigurationProperty(HeaderKey, IsRequired = false, DefaultValue = HeaderDefault)]
        public virtual string Header
        {
            get
            {
                return ((string)(this[HeaderKey]));
            }
            set
            {
                this[HeaderKey] = value;
            }
        }




        [ConfigurationProperty(FooterKey, IsRequired = false, DefaultValue = FooterDefault)]
        public virtual string Footer
        {
            get
            {
                return ((string)(this[FooterKey]));
            }
            set
            {
                this[FooterKey] = value;
            }
        }

        [ConfigurationProperty(DataKey, IsRequired = false, DefaultValue = DataDefault)]
        public virtual string Data
        {
            get
            {
                return ((string)(this[DataKey]));
            }
            set
            {
                this[DataKey] = value;
            }
        }
    }
}