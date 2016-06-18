using Ninja.FileUtil.Provider;

namespace Ninja.FileUtil.Configuration
{
    public class SimpleMode : ISimpleMode, IProviderSettings
    {
        public char Delimeter { get; set; }
        public IDefaultSettings ProviderSettings { get; set; }
    }
}