namespace Ninja.FileUtil.Example
{
    partial class FrmEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpFolderPath = new System.Windows.Forms.GroupBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.grpFileSettings = new System.Windows.Forms.GroupBox();
            this.txtArchiveFolderName = new System.Windows.Forms.TextBox();
            this.chkArcchiveFile = new System.Windows.Forms.CheckBox();
            this.lblArchiveFolder = new System.Windows.Forms.Label();
            this.txtFileFormat = new System.Windows.Forms.TextBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.btnResetParserSettings = new System.Windows.Forms.Button();
            this.btnUpdateParserSettings = new System.Windows.Forms.Button();
            this.grpRowDelimiter = new System.Windows.Forms.GroupBox();
            this.txtDelimiterCharacter = new System.Windows.Forms.TextBox();
            this.lblDelimiterCharacter = new System.Windows.Forms.Label();
            this.grpRowCharacters = new System.Windows.Forms.GroupBox();
            this.txtFooterCharacter = new System.Windows.Forms.TextBox();
            this.txtDataCharacter = new System.Windows.Forms.TextBox();
            this.txtHeaderCharacter = new System.Windows.Forms.TextBox();
            this.lblHeaderCharacter = new System.Windows.Forms.Label();
            this.lblFooterCharacter = new System.Windows.Forms.Label();
            this.lblDataCharacter = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpFolderPath.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.grpFileSettings.SuspendLayout();
            this.grpRowDelimiter.SuspendLayout();
            this.grpRowCharacters.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFolderPath
            // 
            this.grpFolderPath.Controls.Add(this.btnFolder);
            this.grpFolderPath.Controls.Add(this.txtFolderPath);
            this.grpFolderPath.Location = new System.Drawing.Point(22, 31);
            this.grpFolderPath.Name = "grpFolderPath";
            this.grpFolderPath.Size = new System.Drawing.Size(360, 54);
            this.grpFolderPath.TabIndex = 0;
            this.grpFolderPath.TabStop = false;
            this.grpFolderPath.Text = "Select Folder Path";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(287, 19);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(55, 23);
            this.btnFolder.TabIndex = 1;
            this.btnFolder.Text = "Select";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.BtnFolderClick);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(20, 20);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(261, 20);
            this.txtFolderPath.TabIndex = 0;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.grpFolderPath);
            this.grpSettings.Controls.Add(this.grpFileSettings);
            this.grpSettings.Controls.Add(this.btnResetParserSettings);
            this.grpSettings.Controls.Add(this.btnUpdateParserSettings);
            this.grpSettings.Controls.Add(this.grpRowDelimiter);
            this.grpSettings.Controls.Add(this.grpRowCharacters);
            this.grpSettings.Location = new System.Drawing.Point(12, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(761, 232);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // grpFileSettings
            // 
            this.grpFileSettings.Controls.Add(this.txtArchiveFolderName);
            this.grpFileSettings.Controls.Add(this.chkArcchiveFile);
            this.grpFileSettings.Controls.Add(this.lblArchiveFolder);
            this.grpFileSettings.Controls.Add(this.txtFileFormat);
            this.grpFileSettings.Controls.Add(this.lblFileFormat);
            this.grpFileSettings.Location = new System.Drawing.Point(22, 96);
            this.grpFileSettings.Name = "grpFileSettings";
            this.grpFileSettings.Size = new System.Drawing.Size(360, 118);
            this.grpFileSettings.TabIndex = 1;
            this.grpFileSettings.TabStop = false;
            this.grpFileSettings.Text = "File Settings";
            // 
            // txtArchiveFolderName
            // 
            this.txtArchiveFolderName.Location = new System.Drawing.Point(129, 86);
            this.txtArchiveFolderName.Name = "txtArchiveFolderName";
            this.txtArchiveFolderName.Size = new System.Drawing.Size(210, 20);
            this.txtArchiveFolderName.TabIndex = 9;
            // 
            // chkArcchiveFile
            // 
            this.chkArcchiveFile.AutoSize = true;
            this.chkArcchiveFile.Location = new System.Drawing.Point(20, 54);
            this.chkArcchiveFile.Name = "chkArcchiveFile";
            this.chkArcchiveFile.Size = new System.Drawing.Size(145, 17);
            this.chkArcchiveFile.TabIndex = 8;
            this.chkArcchiveFile.Text = "Archive File Upon Read?";
            this.chkArcchiveFile.UseVisualStyleBackColor = true;
            // 
            // lblArchiveFolder
            // 
            this.lblArchiveFolder.AutoSize = true;
            this.lblArchiveFolder.Location = new System.Drawing.Point(17, 89);
            this.lblArchiveFolder.Name = "lblArchiveFolder";
            this.lblArchiveFolder.Size = new System.Drawing.Size(106, 13);
            this.lblArchiveFolder.TabIndex = 7;
            this.lblArchiveFolder.Text = "Archive Folder Name";
            // 
            // txtFileFormat
            // 
            this.txtFileFormat.Location = new System.Drawing.Point(129, 19);
            this.txtFileFormat.Name = "txtFileFormat";
            this.txtFileFormat.Size = new System.Drawing.Size(210, 20);
            this.txtFileFormat.TabIndex = 6;
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Location = new System.Drawing.Point(17, 23);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(95, 13);
            this.lblFileFormat.TabIndex = 1;
            this.lblFileFormat.Text = "File Search Format";
            // 
            // btnResetParserSettings
            // 
            this.btnResetParserSettings.Location = new System.Drawing.Point(626, 92);
            this.btnResetParserSettings.Name = "btnResetParserSettings";
            this.btnResetParserSettings.Size = new System.Drawing.Size(110, 53);
            this.btnResetParserSettings.TabIndex = 6;
            this.btnResetParserSettings.Text = "Reset";
            this.btnResetParserSettings.UseVisualStyleBackColor = true;
            this.btnResetParserSettings.Click += new System.EventHandler(this.BtnResetParserSettingsClick);
            // 
            // btnUpdateParserSettings
            // 
            this.btnUpdateParserSettings.Location = new System.Drawing.Point(626, 159);
            this.btnUpdateParserSettings.Name = "btnUpdateParserSettings";
            this.btnUpdateParserSettings.Size = new System.Drawing.Size(110, 55);
            this.btnUpdateParserSettings.TabIndex = 5;
            this.btnUpdateParserSettings.Text = "Update";
            this.btnUpdateParserSettings.UseVisualStyleBackColor = true;
            this.btnUpdateParserSettings.Click += new System.EventHandler(this.BtnUpdateParserSettingsClick);
            // 
            // grpRowDelimiter
            // 
            this.grpRowDelimiter.Controls.Add(this.txtDelimiterCharacter);
            this.grpRowDelimiter.Controls.Add(this.lblDelimiterCharacter);
            this.grpRowDelimiter.Location = new System.Drawing.Point(400, 159);
            this.grpRowDelimiter.Name = "grpRowDelimiter";
            this.grpRowDelimiter.Size = new System.Drawing.Size(200, 55);
            this.grpRowDelimiter.TabIndex = 4;
            this.grpRowDelimiter.TabStop = false;
            this.grpRowDelimiter.Text = "Row Delimiter";
            // 
            // txtDelimiterCharacter
            // 
            this.txtDelimiterCharacter.Location = new System.Drawing.Point(121, 23);
            this.txtDelimiterCharacter.Name = "txtDelimiterCharacter";
            this.txtDelimiterCharacter.Size = new System.Drawing.Size(49, 20);
            this.txtDelimiterCharacter.TabIndex = 6;
            // 
            // lblDelimiterCharacter
            // 
            this.lblDelimiterCharacter.AutoSize = true;
            this.lblDelimiterCharacter.Location = new System.Drawing.Point(19, 26);
            this.lblDelimiterCharacter.Name = "lblDelimiterCharacter";
            this.lblDelimiterCharacter.Size = new System.Drawing.Size(96, 13);
            this.lblDelimiterCharacter.TabIndex = 3;
            this.lblDelimiterCharacter.Text = "Delimiter Character";
            // 
            // grpRowCharacters
            // 
            this.grpRowCharacters.Controls.Add(this.txtFooterCharacter);
            this.grpRowCharacters.Controls.Add(this.txtDataCharacter);
            this.grpRowCharacters.Controls.Add(this.txtHeaderCharacter);
            this.grpRowCharacters.Controls.Add(this.lblHeaderCharacter);
            this.grpRowCharacters.Controls.Add(this.lblFooterCharacter);
            this.grpRowCharacters.Controls.Add(this.lblDataCharacter);
            this.grpRowCharacters.Location = new System.Drawing.Point(400, 31);
            this.grpRowCharacters.Name = "grpRowCharacters";
            this.grpRowCharacters.Size = new System.Drawing.Size(200, 116);
            this.grpRowCharacters.TabIndex = 3;
            this.grpRowCharacters.TabStop = false;
            this.grpRowCharacters.Text = "Line Heads";
            // 
            // txtFooterCharacter
            // 
            this.txtFooterCharacter.Location = new System.Drawing.Point(121, 78);
            this.txtFooterCharacter.Name = "txtFooterCharacter";
            this.txtFooterCharacter.Size = new System.Drawing.Size(49, 20);
            this.txtFooterCharacter.TabIndex = 5;
            // 
            // txtDataCharacter
            // 
            this.txtDataCharacter.Location = new System.Drawing.Point(121, 47);
            this.txtDataCharacter.Name = "txtDataCharacter";
            this.txtDataCharacter.Size = new System.Drawing.Size(49, 20);
            this.txtDataCharacter.TabIndex = 4;
            // 
            // txtHeaderCharacter
            // 
            this.txtHeaderCharacter.Location = new System.Drawing.Point(121, 18);
            this.txtHeaderCharacter.Name = "txtHeaderCharacter";
            this.txtHeaderCharacter.Size = new System.Drawing.Size(49, 20);
            this.txtHeaderCharacter.TabIndex = 3;
            // 
            // lblHeaderCharacter
            // 
            this.lblHeaderCharacter.AutoSize = true;
            this.lblHeaderCharacter.Location = new System.Drawing.Point(19, 19);
            this.lblHeaderCharacter.Name = "lblHeaderCharacter";
            this.lblHeaderCharacter.Size = new System.Drawing.Size(91, 13);
            this.lblHeaderCharacter.TabIndex = 0;
            this.lblHeaderCharacter.Text = "Header Character";
            // 
            // lblFooterCharacter
            // 
            this.lblFooterCharacter.AutoSize = true;
            this.lblFooterCharacter.Location = new System.Drawing.Point(19, 78);
            this.lblFooterCharacter.Name = "lblFooterCharacter";
            this.lblFooterCharacter.Size = new System.Drawing.Size(86, 13);
            this.lblFooterCharacter.TabIndex = 2;
            this.lblFooterCharacter.Text = "Footer Character";
            // 
            // lblDataCharacter
            // 
            this.lblDataCharacter.AutoSize = true;
            this.lblDataCharacter.Location = new System.Drawing.Point(19, 49);
            this.lblDataCharacter.Name = "lblDataCharacter";
            this.lblDataCharacter.Size = new System.Drawing.Size(79, 13);
            this.lblDataCharacter.TabIndex = 1;
            this.lblDataCharacter.Text = "Data Character";
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 265);
            this.Controls.Add(this.grpSettings);
            this.Name = "FrmEditor";
            this.Text = "Settings Editor";
            this.grpFolderPath.ResumeLayout(false);
            this.grpFolderPath.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpFileSettings.ResumeLayout(false);
            this.grpFileSettings.PerformLayout();
            this.grpRowDelimiter.ResumeLayout(false);
            this.grpRowDelimiter.PerformLayout();
            this.grpRowCharacters.ResumeLayout(false);
            this.grpRowCharacters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFolderPath;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblHeaderCharacter;
        private System.Windows.Forms.Label lblDataCharacter;
        private System.Windows.Forms.GroupBox grpRowDelimiter;
        private System.Windows.Forms.TextBox txtDelimiterCharacter;
        private System.Windows.Forms.Label lblDelimiterCharacter;
        private System.Windows.Forms.GroupBox grpRowCharacters;
        private System.Windows.Forms.TextBox txtFooterCharacter;
        private System.Windows.Forms.TextBox txtDataCharacter;
        private System.Windows.Forms.TextBox txtHeaderCharacter;
        private System.Windows.Forms.Label lblFooterCharacter;
        private System.Windows.Forms.Button btnResetParserSettings;
        private System.Windows.Forms.Button btnUpdateParserSettings;
        private System.Windows.Forms.GroupBox grpFileSettings;
        private System.Windows.Forms.Label lblArchiveFolder;
        private System.Windows.Forms.TextBox txtFileFormat;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.TextBox txtArchiveFolderName;
        private System.Windows.Forms.CheckBox chkArcchiveFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

