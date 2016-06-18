using Ninja.FileUtil.Provider;

namespace Ninja.FileUtil.Configuration
{
    public class FullMode : IFullMode, IProviderSettings
    {
        public char Delimeter { get; set; }

        public string Header { get; set; }
        public string Footer { get; set; }
        public string Data { get; set; }

        public IDefaultSettings ProviderSettings { get; set; }
    }
}
