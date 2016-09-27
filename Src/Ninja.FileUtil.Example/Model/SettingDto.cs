using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.FileUtil.Configuration;

namespace Ninja.FileUtil.Example.Model
{
    public class SettingDto
    {
        public SettingDto(Settings settings)
        {
            Delimiter = settings.ParserSettings.Delimiter;
            Header = settings.ParserSettings.Header;
            Data = settings.ParserSettings.Data;
            Footer = settings.ParserSettings.Footer;
            FolderPath = settings.ProviderSettings.FolderPath;
            FileNameFormat = settings.ProviderSettings.FileNameFormat;
            ArchiveFolder = settings.ProviderSettings.ArchiveFolder;
            ArchiveUponRead = settings.ProviderSettings.ArchiveUponRead;
        }

        public char Delimiter { get; set; }
        public string Header { get; set; }
        public string Data { get; set; }
        public string Footer { get; set; }
        public string FolderPath { get; set; }
        public string FileNameFormat { get; set; }
        public bool ArchiveUponRead { get; set; }
        public string ArchiveFolder { get; set; }
    }
}
