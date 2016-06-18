using Ninja.FileUtil.Provider;

namespace Ninja.FileUtil.Configuration
{
    public class ProviderSettings : IDefaultSettings
    {
        public string FolderPath { get; set; }
        public string FileNameFormat { get; set; }
        public bool ArchiveOnRead { get; set; }
        public string ArchiveFolderPath { get; set; }
    }
}