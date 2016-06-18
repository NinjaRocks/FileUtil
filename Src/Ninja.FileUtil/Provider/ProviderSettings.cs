namespace Ninja.FileUtil.Provider
{
    public class ProviderSettings
    {
        public string FolderPath { get; set; }
        public string FileNameFormat { get; set; }
        public bool ArchiveOnRead { get; set; }
        public string ArchiveFolderPath { get; set; }
    }
}