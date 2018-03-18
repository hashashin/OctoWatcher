﻿namespace OctoWatcher
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.watchFolder = new System.Windows.Forms.TextBox();
            this.pickWatchFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.octoPrintAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apiKey = new System.Windows.Forms.TextBox();
            this.enableKeywords = new System.Windows.Forms.CheckBox();
            this.localUpload = new System.Windows.Forms.CheckBox();
            this.enableWatch = new System.Windows.Forms.CheckBox();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.saveProfile = new System.Windows.Forms.Button();
            this.deleteProfile = new System.Windows.Forms.Button();
            this.newProfile = new System.Windows.Forms.Button();
            this.profileList = new System.Windows.Forms.ComboBox();
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuicono = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.start_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimized = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.close = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuicono.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Watch Folder";
            // 
            // watchFolder
            // 
            this.watchFolder.Location = new System.Drawing.Point(12, 74);
            this.watchFolder.Name = "watchFolder";
            this.watchFolder.Size = new System.Drawing.Size(218, 20);
            this.watchFolder.TabIndex = 1;
            // 
            // pickWatchFolder
            // 
            this.pickWatchFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickWatchFolder.Location = new System.Drawing.Point(236, 74);
            this.pickWatchFolder.Name = "pickWatchFolder";
            this.pickWatchFolder.Size = new System.Drawing.Size(36, 20);
            this.pickWatchFolder.TabIndex = 2;
            this.pickWatchFolder.Text = "...";
            this.pickWatchFolder.UseVisualStyleBackColor = true;
            this.pickWatchFolder.Click += new System.EventHandler(this.PickWatchFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OctoPrint Address";
            // 
            // octoPrintAddress
            // 
            this.octoPrintAddress.Cursor = System.Windows.Forms.Cursors.Default;
            this.octoPrintAddress.Location = new System.Drawing.Point(12, 113);
            this.octoPrintAddress.Name = "octoPrintAddress";
            this.octoPrintAddress.Size = new System.Drawing.Size(260, 20);
            this.octoPrintAddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "OctoPrint API Key";
            // 
            // apiKey
            // 
            this.apiKey.Location = new System.Drawing.Point(12, 152);
            this.apiKey.Name = "apiKey";
            this.apiKey.Size = new System.Drawing.Size(260, 20);
            this.apiKey.TabIndex = 6;
            // 
            // enableKeywords
            // 
            this.enableKeywords.AutoSize = true;
            this.enableKeywords.Checked = true;
            this.enableKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableKeywords.Location = new System.Drawing.Point(12, 178);
            this.enableKeywords.Name = "enableKeywords";
            this.enableKeywords.Size = new System.Drawing.Size(108, 17);
            this.enableKeywords.TabIndex = 7;
            this.enableKeywords.Text = "Enable Keywords";
            this.enableKeywords.UseVisualStyleBackColor = true;
            // 
            // localUpload
            // 
            this.localUpload.AutoSize = true;
            this.localUpload.Checked = true;
            this.localUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localUpload.Location = new System.Drawing.Point(12, 201);
            this.localUpload.Name = "localUpload";
            this.localUpload.Size = new System.Drawing.Size(141, 17);
            this.localUpload.TabIndex = 8;
            this.localUpload.Text = "Upload to Local Storage";
            this.localUpload.UseVisualStyleBackColor = true;
            // 
            // enableWatch
            // 
            this.enableWatch.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableWatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableWatch.Location = new System.Drawing.Point(12, 248);
            this.enableWatch.Name = "enableWatch";
            this.enableWatch.Size = new System.Drawing.Size(260, 49);
            this.enableWatch.TabIndex = 9;
            this.enableWatch.Text = "Start Watching";
            this.enableWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableWatch.UseVisualStyleBackColor = true;
            this.enableWatch.CheckedChanged += new System.EventHandler(this.EnableWatch_CheckedChanged);
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(12, 224);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(162, 17);
            this.autoStart.TabIndex = 10;
            this.autoStart.Text = "Automatically Start Watching";
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Profile";
            // 
            // saveProfile
            // 
            this.saveProfile.Location = new System.Drawing.Point(174, 32);
            this.saveProfile.Name = "saveProfile";
            this.saveProfile.Size = new System.Drawing.Size(46, 23);
            this.saveProfile.TabIndex = 14;
            this.saveProfile.Text = "Save";
            this.saveProfile.UseVisualStyleBackColor = true;
            this.saveProfile.Click += new System.EventHandler(this.SaveProfile_Click);
            // 
            // deleteProfile
            // 
            this.deleteProfile.Location = new System.Drawing.Point(226, 32);
            this.deleteProfile.Name = "deleteProfile";
            this.deleteProfile.Size = new System.Drawing.Size(46, 23);
            this.deleteProfile.TabIndex = 15;
            this.deleteProfile.Text = "Delete";
            this.deleteProfile.UseVisualStyleBackColor = true;
            this.deleteProfile.Click += new System.EventHandler(this.DeleteProfile_Click);
            // 
            // newProfile
            // 
            this.newProfile.Location = new System.Drawing.Point(129, 33);
            this.newProfile.Name = "newProfile";
            this.newProfile.Size = new System.Drawing.Size(39, 22);
            this.newProfile.TabIndex = 16;
            this.newProfile.Text = "New";
            this.newProfile.UseVisualStyleBackColor = true;
            this.newProfile.Click += new System.EventHandler(this.NewProfile_Click);
            // 
            // profileList
            // 
            this.profileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileList.FormattingEnabled = true;
            this.profileList.Location = new System.Drawing.Point(12, 33);
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(108, 21);
            this.profileList.TabIndex = 12;
            this.profileList.SelectedIndexChanged += new System.EventHandler(this.ProfileList_SelectedIndexChanged);
            // 
            // icon
            // 
            this.icon.ContextMenuStrip = this.menuicono;
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "OctoWatcher";
            this.icon.Visible = true;
            // 
            // menuicono
            // 
            this.menuicono.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.start_stop,
            this.startMinimized,
            this.toolStripSeparator1,
            this.close});
            this.menuicono.Name = "menuicono";
            this.menuicono.Size = new System.Drawing.Size(175, 76);
            // 
            // start_stop
            // 
            this.start_stop.Image = global::OctoWatcher.Properties.Resources._293a5289d4fb9d7440f4c9151508f0d0_icon;
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(174, 22);
            this.start_stop.Text = this.enableWatch.Text;
            this.start_stop.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // startMinimized
            // 
            this.startMinimized.CheckOnClick = true;
            this.startMinimized.Image = global::OctoWatcher.Properties.Resources._63053_200;
            this.startMinimized.Name = "startMinimized";
            this.startMinimized.Size = new System.Drawing.Size(174, 22);
            this.startMinimized.Text = "Start minimized";
            this.startMinimized.Click += new System.EventHandler(this.ToolStripMenuItem1_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // close
            // 
            this.close.Image = global::OctoWatcher.Properties.Resources.close_button_icon_30064;
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(174, 22);
            this.close.Text = "Close Octowatcher";
            this.close.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 330);
            this.Controls.Add(this.newProfile);
            this.Controls.Add(this.deleteProfile);
            this.Controls.Add(this.saveProfile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.profileList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.enableWatch);
            this.Controls.Add(this.localUpload);
            this.Controls.Add(this.enableKeywords);
            this.Controls.Add(this.apiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.octoPrintAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pickWatchFolder);
            this.Controls.Add(this.watchFolder);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "OctoWatcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuicono.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox watchFolder;
        private System.Windows.Forms.Button pickWatchFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox octoPrintAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apiKey;
        private System.Windows.Forms.CheckBox enableKeywords;
        private System.Windows.Forms.CheckBox localUpload;
        private System.Windows.Forms.CheckBox enableWatch;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveProfile;
        private System.Windows.Forms.Button deleteProfile;
        private System.Windows.Forms.Button newProfile;
        private System.Windows.Forms.ComboBox profileList;
        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip menuicono;
        private System.Windows.Forms.ToolStripMenuItem start_stop;
        private System.Windows.Forms.ToolStripMenuItem close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startMinimized;
    }
}