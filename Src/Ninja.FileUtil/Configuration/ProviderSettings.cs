using System.Configuration;

namespace Ninja.FileUtil.Configuration
{
    public class ProviderSettings : ConfigurationElement, IProviderSettings
    {
        private const string FolderPathKey = "folderPath";
        private const string FileNameFormatKey = "fileNameFormat";
        private const string ArchiveUponReadKey = "archiveUponRead";
        private const string ArchiveFolderKey = "archiveFolder";

        public const bool ArchiveUponReadDefault = true;
        public const string ArchiveFolderDefault = "Archived";

        [ConfigurationProperty(FolderPathKey, IsRequired = true)]
        public virtual string FolderPath
        {
            get
            {
                return ((string)(this[FolderPathKey]));
            }
            set
            {
                this[FolderPathKey] = value;
            }
        }


        [ConfigurationProperty(FileNameFormatKey, IsRequired = false)]
        public virtual string FileNameFormat
        {
            get
            {
                return ((string)(this[FileNameFormatKey]));
            }
            set
            {
                this[FileNameFormatKey] = value;
            }
        }

        [ConfigurationProperty(ArchiveUponReadKey, IsRequired = false, DefaultValue = ArchiveUponReadDefault)]
        public virtual bool ArchiveUponRead
        {
            get
            {
                return ((bool)(this[ArchiveUponReadKey]));
            }
            set
            {
                this[ArchiveUponReadKey] = value;
            }
        }

        [ConfigurationProperty(ArchiveFolderKey, IsRequired = false, DefaultValue = ArchiveFolderDefault)]
        public virtual string ArchiveFolder
        {
            get
            {
                return ((string)(this[ArchiveFolderKey]));
            }
            set
            {
                this[ArchiveFolderKey] = value;
            }
        }
    }
}