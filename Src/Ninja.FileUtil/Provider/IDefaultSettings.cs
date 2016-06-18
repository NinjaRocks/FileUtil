namespace Ninja.FileUtil.Provider
{
    public interface IDefaultSettings
    {
        string FolderPath { get; set; }
        string FileNameFormat { get; set; }
        bool ArchiveOnRead { get; set; }
        string ArchiveFolderPath { get; set; }
    }
}