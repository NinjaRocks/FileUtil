using System;
using System.IO;
using System.Windows.Forms;
using Ninja.FileUtil.Example.Impl;
using Ninja.FileUtil.Example.Model;

namespace Ninja.FileUtil.Example
{
    public partial class FrmEditor : Form
    {
        private SettingDto settings;
   

        public FrmEditor()
        {
            settings = ConfigCache.Get();
            InitializeComponent();
            BindSettings();
        }

        private void BtnFolderClick(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                settings.FolderPath = folderBrowserDialog.SelectedPath;

            BindSettings();
        }

        private void BtnResetParserSettingsClick(object sender, EventArgs e)
        {
            settings = ConfigCache.Update(null);
            BindSettings();
        }

        private void BindSettings()
        {
            txtArchiveFolderName.Text = settings.ArchiveFolder;
            txtFolderPath.Text = settings.FolderPath;
            chkArcchiveFile.Checked = settings.ArchiveUponRead;
            txtFileFormat.Text = settings.FileNameFormat;

            txtDelimiterCharacter.Text = settings.Delimiter.ToString();
            txtHeaderCharacter.Text = settings.Header;
            txtDataCharacter.Text = settings.Data;
            txtFooterCharacter.Text = settings.Footer;

        }

        private void BtnUpdateParserSettingsClick(object sender, EventArgs e)
        {
            settings.FolderPath = txtFolderPath.Text.GetValueOrDefault(settings.FolderPath);
            settings.FileNameFormat = txtFileFormat.Text.GetValueOrDefault(settings.FileNameFormat);
            settings.ArchiveUponRead = chkArcchiveFile.Checked;
            settings.ArchiveFolder = txtArchiveFolderName.Text.GetValueOrDefault(settings.ArchiveFolder);


            settings.Delimiter = Convert.ToChar(txtDelimiterCharacter.Text.GetValueOrDefault(settings.Delimiter.ToString()));
            settings.Header = txtHeaderCharacter.Text.GetValueOrDefault(settings.Header);
            settings.Data = txtDataCharacter.Text.GetValueOrDefault(settings.Data);
            settings.Footer = txtFooterCharacter.Text.GetValueOrDefault(settings.Footer);

            ConfigCache.Update(settings);
        }
    }
}
