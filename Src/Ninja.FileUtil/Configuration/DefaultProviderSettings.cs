namespace Ninja.FileUtil.Configuration
{
    public class DefaultProviderSettings
    {
        public string FolderPath { get; set; }
        public string FileNameFormat { get; set; }
        public bool ArchiveOnRead { get; set; }
        public string ArchiveFolderPath { get; set; }
    }
}