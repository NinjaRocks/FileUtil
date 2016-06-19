using System.Configuration;

namespace Ninja.FileUtil.Configuration
{
    public class ProviderSettings : ConfigurationElement, IProviderSettings
    {
        private const string FolderPathKey = "FolderPath";
        private const string FileNameFormatKey = "FileNameFormat";
        private const string ArchiveUponReadKey = "ArchiveUponRead";
        private const string ArchiveFolderKey = "ArchiveFolder";

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

        [ConfigurationProperty(ArchiveUponReadKey, IsRequired = false, DefaultValue = true)]
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

        [ConfigurationProperty(ArchiveFolderKey, IsRequired = true, DefaultValue = "Archived")]
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