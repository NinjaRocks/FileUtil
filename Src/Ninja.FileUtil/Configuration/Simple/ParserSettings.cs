using System.Configuration;

namespace Ninja.FileUtil.Configuration.Simple
{
    public class ParserSettings : ConfigurationElement, IConfiguration
    {
        private const string DelimeterKey = "Delimeter";


        [ConfigurationProperty(DelimeterKey, IsRequired = false, DefaultValue = '|')]
        public char Delimeter
        {
            get { return ((char) (this[DelimeterKey])); }
            set { this[DelimeterKey] = value; }
        }
    }
}