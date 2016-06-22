using System.Configuration;

namespace Ninja.FileUtil.Configuration.Full
{
    public class ParserSettings : ConfigurationElement, IConfiguration
    {
        private const string DelimeterKey = "Delimeter";
        private const string HeaderKey = "Header";
        private const string FooterKey = "Footer";
        private const string DataKey = "Data";
        
        [ConfigurationProperty(DelimeterKey, IsRequired = false, DefaultValue = '|')]
        public char Delimeter
        {
            get
            {
                return ((char)(this[DelimeterKey]));
            }
            set
            {
                this[DelimeterKey] = value;
            }
        }

        [ConfigurationProperty(HeaderKey, IsRequired = false, DefaultValue = "H")]
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




        [ConfigurationProperty(FooterKey, IsRequired = false, DefaultValue = "F")]
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

        [ConfigurationProperty(DataKey, IsRequired = false, DefaultValue = "D")]
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