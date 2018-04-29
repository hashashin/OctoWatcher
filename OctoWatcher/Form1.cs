using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Temp.IO;
using Gajatko.IniFiles;
using OctoWatcher.Properties;

namespace OctoWatcher
{
    public partial class MainForm : Form
    {
        private readonly MyFileSystemWatcher _fsWatcher = new MyFileSystemWatcher();
        private readonly MyFileSystemWatcher _fsWatcherstl = new MyFileSystemWatcher();

        private readonly string _cfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/octowatcher.ini";

        private string _lastName;
        //private DateTime lasTime;

        public MainForm()
        {
            InitializeComponent();
            icon.DoubleClick += NotifyIcon1_MouseDoubleClick;
            Resize += MainForm_Resize;
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                IniFile.FromFile(_cfile);
            }
            else
            {
                config["Default"]["watchFolder"] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                config["Default"]["octoPrintAddress"] = "https://octoprint.local";
                config["Default"]["apiKey"] = "Enter API Key";
                config["Default"]["enableKeywords"] = "true";
                config["Default"]["localUpload"] = "true";
                config["Default"]["autoStart"] = "false";
                config["Default"]["startMinimized"] = "false";
                config["Default"]["layerInfo"] = "true";
                config.Save(_cfile);
            }

            RefreshProfileList();

            LoadSettings();
            if (!startMinimized.Checked) return;
            WindowState = FormWindowState.Minimized;
            Hide();
            ShowInTaskbar = false;
            if (autoStart.Checked)
            {
                enableWatch.Checked = true;
            }
        }

        private void RefreshProfileList(string selectedProfile = "Default")
        {
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(_cfile);
            }

            profileList.Items.Clear();
            int index = 0;
            string[] sections = config.GetSectionNames();
            foreach (string name in sections)
            {
                profileList.Items.Add(name);
                if (name == selectedProfile)
                {
                    profileList.SelectedIndex = index;
                }

                index++;
            }

        }

        private void EnableWatch_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
            if (enableWatch.Checked)
            {
                _fsWatcher.Path = watchFolder.Text;
                _fsWatcher.Filter = "*.gco*"; // only watch for gcode
                _fsWatcher.NotifyFilter = NotifyFilters.LastWrite;
                _fsWatcher.Changed += OnChanged;
                _fsWatcher.IncludeSubdirectories = true;
                _fsWatcher.EnableRaisingEvents = true;
                _fsWatcherstl.Path = watchFolder.Text;
                _fsWatcherstl.Filter = "*.stl"; // only watch for gcode
                _fsWatcherstl.NotifyFilter = NotifyFilters.LastWrite;
                _fsWatcherstl.Changed += OnChanged;
                _fsWatcherstl.IncludeSubdirectories = true;
                _fsWatcherstl.EnableRaisingEvents = true;
                statusLabel.Text = Resources.mainForm_enableWatch_CheckedChanged_Watching_Folder_for_files_;
                enableWatch.Text = Resources.mainForm_enableWatch_CheckedChanged_Stop_Watching;
                start_stop.Image = Resources._293a5289d4fb9d7440f4c9151508f0d0_icon2;
                start_stop.Text = enableWatch.Text;
                icon.BalloonTipText = Resources.mainForm_enableWatch_CheckedChanged_Watching_Folder_for_files_;
                icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
            }
            else
            {
                _fsWatcher.EnableRaisingEvents = false;
                _fsWatcherstl.EnableRaisingEvents = false;
                enableWatch.Text = Resources.mainForm_enableWatch_CheckedChanged_Start_Watching;
                start_stop.Text = enableWatch.Text;
                start_stop.Image = Resources._293a5289d4fb9d7440f4c9151508f0d0_icon;
                statusLabel.Text = Resources.mainForm_enableWatch_CheckedChanged_Watching_disabled_;
                icon.BalloonTipText = Resources.mainForm_enableWatch_CheckedChanged_Watching_disabled_;
                icon.ShowBalloonTip(100,"", icon.BalloonTipText, ToolTipIcon.Info);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState) return;
            //icon.BalloonTipText = Resources.mainForm_MainForm_Resize_Minimized_to_tray_;
            //icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
            Hide();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            Show();
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void Run_analysis(string arg)
        {
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(@"Q:\octoprint_post\analysis\venv\Scripts\analysis.exe",
                    "--speed-x=1000 --speed-y=1000 --max-t=10 " + "\"" + arg + "\"")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            p.Start();
            //string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            var time = p.ExitTime.TimeOfDay.TotalSeconds - p.StartTime.TimeOfDay.TotalSeconds;
            time = Math.Round(time, 0);
            icon.BalloonTipText = $@"gcode processed in: {time}secs.";
            icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
            statusLabel.Text = $@"gcode processed in: {time}secs.";
        }

        private void Run_insert(string eFullPath)
        {
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(@"Q:\octoprint_post\analysis\venv\Scripts\python.exe",
                    "Q:\\octoprint_post\\analysis\\insert_m117.py \"" + eFullPath + "\"")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            p.Start();
            //string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (_lastName == e.Name || !File.Exists(e.FullPath) || _lastName == "done")
            {
                _lastName = _lastName == "done" ? "" : e.Name;
                return;
            }

            if (e.Name.Contains(".stl"))
            {
                icon.BalloonTipText = Resources.MainForm_OnChanged_New_stl_file_detected__uploading__ + e.Name;
                icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
                Do_upload(e.FullPath);
                File.Delete(e.FullPath);
                _lastName = "done";
                return;
            }
            _lastName = e.Name;
            //fsWatcher.EnableRaisingEvents = false;
            icon.BalloonTipText = Resources.MainForm_OnChanged_New_file_detected__Preprocessing__ + e.Name;
            icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
            if (layerInfo.Checked)
            {
                Run_insert(e.FullPath);
            }
            Run_analysis(e.FullPath);
            //icon.BalloonTipText = "Uploading: " + e.Name;
            //icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
            Do_upload(e.FullPath);
            File.Delete(e.FullPath);
            _lastName = "done";
        }

        private void Do_upload(string filename)
        {
            System.Threading.Thread.Sleep(5000);
            NameValueCollection parameters = new NameValueCollection();
            string url = octoPrintAddress.Text + "/api/files/";
            string prepend = "http://";
            if (octoPrintAddress.Text.StartsWith("http://"))
            {
                prepend = "";
            }

            if (octoPrintAddress.Text.StartsWith("https://"))
            {
                prepend = "";
            }

            string uploadName = Path.GetFileName(filename); // need to get just the filename portion
            string uploadedFileStatus = "Uploaded " + uploadName;
            if (localUpload.Checked || filename.Contains(".stl"))
            {
                url = url + "local";
            }
            else
            {
                url = url + "sdcard";
            }

            // process filename here.
            if (enableKeywords.Checked &! filename.Contains(".stl"))
            {
                if (uploadName != null && uploadName.Contains("-select.gco"))
                {
                    parameters.Add("select", "true");
                    uploadName = uploadName.Replace("-select.gco", ".gco");
                    uploadedFileStatus += " as " + uploadName;
                }

                if (uploadName != null && uploadName.Contains("-print.gco"))
                {
                    parameters.Add("print", "true");
                    uploadName = uploadName.Replace("-print.gco", ".gco");
                    uploadedFileStatus += " as " + uploadName;
                }
            }
            else
            {
                parameters.Add("select", "false");
                parameters.Add("print", "false");
            }

            UploadMultipart(File.ReadAllBytes(filename), uploadName, "application/octet-stream", prepend + url,
                apiKey.Text, parameters);

            statusLabel.Text = uploadedFileStatus;
            icon.BalloonTipText = uploadedFileStatus;
            icon.ShowBalloonTip(100, "", icon.BalloonTipText, ToolTipIcon.Info);
        }


        private void UploadMultipart(byte[] file, string filename, string contentType, string url, string apikey,
            NameValueCollection parameters)
        {
            var webClient = new WebClient();
            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
            webClient.Headers.Add("X-Api-Key", apikey);
            webClient.QueryString = parameters;
            var fileData = webClient.Encoding.GetString(file);
            var package =
                string.Format(
                    "--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n",
                    boundary, filename, contentType, fileData);

            var nfile = webClient.Encoding.GetBytes(package);

            webClient.UploadData(url, "POST", nfile);
            //fsWatcher.EnableRaisingEvents = true;
        }

        private void PickWatchFolder_Click(object sender, EventArgs e)
        {
            folderPicker.ShowNewFolderButton = true; // they can make new folders, duh!
            folderPicker.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = folderPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                watchFolder.Text = folderPicker.SelectedPath;
            }
        }

        private void SaveSettings()
        {
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(_cfile);
            }

            string profileName = profileList.Text;
            if (profileName != "")
            {
                config[profileName]["watchFolder"] = watchFolder.Text;
                config[profileName]["octoPrintAddress"] = octoPrintAddress.Text;
                config[profileName]["apiKey"] = apiKey.Text;
                config[profileName]["enableKeywords"] = enableKeywords.Checked.ToString();
                config[profileName]["localUpload"] = localUpload.Checked.ToString();
                config[profileName]["autoStart"] = autoStart.Checked.ToString();
                config[profileName]["startMinimized"] = startMinimized.Checked.ToString();
                config[profileName]["layerInfo"] = layerInfo.Checked.ToString();
                config.Save(_cfile);

                IniFile.FromFile(_cfile);
            }
        }

        private void LoadSettings()
        {
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(_cfile);
            }

            string profileName = profileList.Text;
            if (config[profileName] != null)
            {
                // it exists, load the profile
                watchFolder.Text = config[profileName]["watchFolder"];
                octoPrintAddress.Text = config[profileName]["octoPrintAddress"];
                apiKey.Text = config[profileName]["apiKey"];
                enableKeywords.Checked = Convert.ToBoolean(config[profileName]["enableKeywords"]);
                localUpload.Checked = Convert.ToBoolean(config[profileName]["localUpload"]);
                autoStart.Checked = Convert.ToBoolean(config[profileName]["autoStart"]);
                startMinimized.Checked = Convert.ToBoolean(config[profileName]["startMinimized"]);
                layerInfo.Checked = Convert.ToBoolean(config[profileName]["layerInfo"]);
            }
            else
            {
                // set to defaults
                profileName = "Default";
                watchFolder.Text = config[profileName]["watchFolder"];
                octoPrintAddress.Text = config[profileName]["octoPrintAddress"];
                apiKey.Text = config[profileName]["apiKey"];
                enableKeywords.Checked = Convert.ToBoolean(config[profileName]["enableKeywords"]);
                localUpload.Checked = Convert.ToBoolean(config[profileName]["localUpload"]);
                autoStart.Checked = Convert.ToBoolean(config[profileName]["autoStart"]);
                startMinimized.Checked = Convert.ToBoolean(config[profileName]["startMinimized"]);
                layerInfo.Checked = Convert.ToBoolean(config[profileName]["layerInfo"]);
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveProfile_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void DeleteProfile_Click(object sender, EventArgs e)
        {
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(_cfile);
            }

            string profileToDelete = profileList.Text;
            config.DeleteSection(profileToDelete);
            config.Save(_cfile);
            RefreshProfileList();
        }

        private void ProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void NewProfile_Click(object sender, EventArgs e)
        {
            IniFile config = new IniFile();
            if (File.Exists(_cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(_cfile);
            }

            string profileName = "New Profile";
            if (InputBox("Profile Name", "New Profile Name:", ref profileName) != DialogResult.OK) return;
            // create a new profile with the name!
            config[profileName]["watchFolder"] = watchFolder.Text;
            config[profileName]["octoPrintAddress"] = octoPrintAddress.Text;
            config[profileName]["apiKey"] = apiKey.Text;
            config[profileName]["enableKeywords"] = enableKeywords.Checked.ToString();
            config[profileName]["localUpload"] = localUpload.Checked.ToString();
            config[profileName]["autoStart"] = autoStart.Checked.ToString();
            config[profileName]["startMinimized"] = startMinimized.Checked.ToString();
            config[profileName]["layerInfo"] = layerInfo.Checked.ToString();
            config.Save(_cfile);
            IniFile.FromFile(_cfile);
            RefreshProfileList(profileName);
        }

        private static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = Resources.MainForm_InputBox_OK;
            buttonCancel.Text = Resources.MainForm_InputBox_Cancel;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enableWatch.Checked = !enableWatch.Checked;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            enableWatch.Checked = false;
            Close();
        }

        private void ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }
    }
}