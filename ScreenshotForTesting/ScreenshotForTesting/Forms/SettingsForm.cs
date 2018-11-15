using ScreenshotApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotForTesting.Forms
{
    public partial class SettingsForm : Form
    {
        bool first = true;

        public SettingsForm()
        {
            InitializeComponent();

            groupBox1.SendToBack();
            FillOutSavePath();
            folderBrowserDialog1.SelectedPath = SavePath.Text;
            folderBrowserDialog1.Description = "Please select a folder to save screenshots to.";

            var snipMod = Properties.Settings.Default["SnipMod"].ToString();
            var snipKey = Properties.Settings.Default["SnipKey"].ToString();
            var captureMod = Properties.Settings.Default["CaptureMod"].ToString();
            var captureKey = Properties.Settings.Default["CaptureKey"].ToString();

            if (snipMod == "") snipMod = "Ctrl";
            if (snipKey == "") snipKey = "M";
            if (captureMod == "") captureMod = "Ctrl + Alt";
            if (captureKey == "") captureKey = "M";

            ScreenCapMod.Text = captureMod;
            ScreenCapKey.Text = captureKey;
            SnipMod.Text = snipMod;
            SnipKey.Text = snipKey;

            StartPosition = FormStartPosition.CenterParent;
            first = false;

            if (ScreenshotForTesting.Properties.Settings.Default["Preview"].ToString() == "Y")
            {
                checkBox1.Checked = true;
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        private void ScreenCapMod_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        private void UpdateHotKey()
        {
            var screenCapMod = ScreenCapMod.Text;
            var screenCapKey = ScreenCapKey.Text;
            var snipMod = SnipMod.Text;
            var snipKey = SnipKey.Text;

            if (screenCapMod + screenCapKey == snipMod + snipKey)
            {
                MessageBox.Show("Both Hot Key's can't be the same.", "Invalid Hot Key",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (snipMod == "") snipMod = "Ctrl";
            if (snipKey == "") snipKey = "M";
            if (screenCapMod == "") screenCapMod = "Ctrl + Alt";
            if (screenCapKey == "") screenCapKey = "M";

            //Update persistant info.
            Properties.Settings.Default["CaptureMod"] = screenCapMod;
            Properties.Settings.Default["CaptureKey"] = screenCapKey;
            Properties.Settings.Default["SnipMod"] = snipMod;
            Properties.Settings.Default["SnipKey"] = snipKey;

            Properties.Settings.Default.Save();

            MainForm.hotkey.UnRegisterHotKeys();
            MainForm.hotkey.SetWindowCaptureHotkey(screenCapMod, screenCapKey);
            MainForm.hotkey.SetSnipHotkey(snipMod, snipKey);
        }

        private void ScreenCapKey_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        private void SnipMod_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        private void SnipKey_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        public void FillOutSavePath()
        {
            string path;

            if (ScreenshotForTesting.Properties.Settings.Default["SavePath"].ToString() == "")
            {
                path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Screenshot Testing Tool";
            }
            else
            {
                path = ScreenshotForTesting.Properties.Settings.Default["SavePath"].ToString();
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            SavePath.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            var selectedPath = folderBrowserDialog1.SelectedPath;

            if (selectedPath == "")
            {
                return;
            }

            SavePath.Text = folderBrowserDialog1.SelectedPath;
            MainForm.SavePathLocation = folderBrowserDialog1.SelectedPath;
        }

        private void SavePath_TextChanged(object sender, EventArgs e)
        {
            //Update persistant info.
            Properties.Settings.Default["SavePath"] = SavePath.Text;
            Properties.Settings.Default.Save();

            folderBrowserDialog1.SelectedPath = SavePath.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Preview"] = checkBox1.Checked ? "Y" : "N";
            Properties.Settings.Default.Save();

            MainForm.preview = checkBox1.Checked;
        }
    }
}