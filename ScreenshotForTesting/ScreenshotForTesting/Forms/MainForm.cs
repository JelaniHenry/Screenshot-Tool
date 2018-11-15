using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using ScreenshotForTesting;
using System.Collections.Specialized;
using ScreenshotForTesting.Forms;
using System.Threading.Tasks;
using System.Net.Mail;
using Tesseract;

namespace ScreenshotApp
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        private IntPtr thisWindow;
        public static Hotkey hotkey;
        public static bool preview = ScreenshotForTesting.Properties.Settings.Default["Preview"].ToString() == "Y";
        public static string SavePathLocation = "";
        private int imageCount = 1;
        private string previousFileName = "";
        private string lastScreenshot = "";
        private List<string> previousCaptures = new List<string>();
        private bool inProgress = false;
        public int ImageCount = 1;

        public MainForm()
        {
            InitializeComponent();
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

            SavePathLocation = path;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            thisWindow = FindWindow(null, "Screenshot Tool");

            FillOutSavePath();

            hotkey = new Hotkey(thisWindow);

            var snipMod = ScreenshotForTesting.Properties.Settings.Default["SnipMod"].ToString();
            var snipKey = ScreenshotForTesting.Properties.Settings.Default["SnipKey"].ToString();
            var captureMod = ScreenshotForTesting.Properties.Settings.Default["CaptureMod"].ToString();
            var captureKey = ScreenshotForTesting.Properties.Settings.Default["CaptureKey"].ToString();

            if (snipMod == "") snipMod = "Ctrl";
            if (snipKey == "") snipKey = "M";
            if (captureMod == "") captureMod = "Ctrl + Alt";
            if (captureKey == "") captureKey = "M";

            hotkey.SetSnipHotkey(snipMod, snipKey);
            hotkey.SetWindowCaptureHotkey(captureMod, captureKey);

            Filename.Text = "File Name";

            InitializeToolTips();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotkey.UnRegisterHotKeys();
        }

        public bool VerifyFileNameNotEmpty()
        {
            if ("" == Filename.Text)
            {
                Activate();

                MessageBox.Show("Please enter a file name before taking a screenshot.", "File Name Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        public void OnKeyCommon(Bitmap image)
        {
            pictureBox1.Cursor = Cursors.Hand;

            var filepath = SavePathLocation;

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var filename = Filename.Text;

            if (filename != previousFileName)
            {
                imageCount = 1;
            }

            var completeScreenshotPath = string.Format("{0}//{1}-{2}.jpg", filepath, filename, imageCount);

            Common.SaveBitmap(image, completeScreenshotPath);

            previousFileName = filename;
            lastScreenshot = completeScreenshotPath;

            //Update image to display new screenshot.
            pictureBox1.ImageLocation = lastScreenshot;

            //Add Image to the image history list.
            CaptureHistory.Items.Add(filename + "-" + imageCount);

            //Clear everything highlighted in Capturehistory.
            for (int i = 0; i < CaptureHistory.SelectedIndices.Count; i++)
            {
                CaptureHistory.Items[CaptureHistory.SelectedIndices[i]].Selected = false;
            }

            CaptureHistory.Items[CaptureHistory.Items.Count - 1].EnsureVisible();

            previousCaptures.Add(completeScreenshotPath);

            imageCount++;

            //If Preview Capture checkbox is checked display active.
            if (preview)
            {
                Activate();
            }
            pictureBox1.Enabled = true;
        }

        public void OnMKey()
        {
            if (!VerifyFileNameNotEmpty())
            {
                Activate();
                return;
            }

            ScreenCapture screenshot = new ScreenCapture();
            var takenScreenshot = screenshot.Capture();

            OnKeyCommon(takenScreenshot);
        }

        public void OnNKey()
        {
            if (!VerifyFileNameNotEmpty())
            {
                return;
            }

            inProgress = true;

            var snippingForm = new SnippingForm();

            if (snippingForm.ShowDialog() == DialogResult.OK)
            {
                OnKeyCommon(snippingForm.CaptureFromSnip);
            }

            inProgress = false;
        }

        protected override void WndProc(ref Message keyPressed)
        {
            if (keyPressed.Msg == 0x0312)
            {
                if (inProgress)
                {
                    return;
                }

                switch (keyPressed.WParam.ToInt32())
                {
                    case 1:
                        OnMKey();
                        break;

                    case 2:
                        OnNKey();
                        break;
                }
            }
            base.WndProc(ref keyPressed);
        }

        private void InstructionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ctrl + M will take a screenshot of the active window.\n" +
                            "Ctrl + N will allow for a snipping tool like function.\n" +
                            "Press the '...' button to change the save location.\n" +
                            "Images under Screenshot History can be copied to other windows. For example, drag links into emails, JIRA or anywhere a file is accepted.\n" +
                            "Screenshots will have a counter appended to the file name to allow consecutive captures with the same file name.\n" +
                            "Counter resets when file name changes.\n" +
                            "Double click file name to rename file.\n",
                            "Screenshot Tool Instructions",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BrowseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(SavePathLocation);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(pictureBox1.ImageLocation);
        }

       
        public void InitializeToolTips()
        {
            //// Create the ToolTip and associate with the Form container.
            //ToolTip toolTip1 = new ToolTip();

            //// Set up the delays for the ToolTip.
            ////toolTip1.AutoPopDelay = 5000;
            ////toolTip1.InitialDelay = 1000;
            ////toolTip1.ReshowDelay = 500;
            //// Force the ToolTip text to be displayed whether or not the form is active.
            //toolTip1.ShowAlways = true;

            //// Set up the ToolTip text for the Button and Checkbox.
            //toolTip1.SetToolTip(label1, "Double click an entry to rename file. Sin");
            //toolTip1.SetToolTip(this.checkBox1, "My checkBox1");
        }

        private void CaptureHistory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var selectedFiles = new List<string>();

            foreach (ListViewItem selecteditem in CaptureHistory.SelectedItems)
            {
                selectedFiles.Add(previousCaptures[CaptureHistory.Items.IndexOf(selecteditem)]);
            }

            DataObject data = new DataObject(DataFormats.FileDrop, selectedFiles.ToArray());
            DoDragDrop(data, DragDropEffects.Copy);
        }

        private void CaptureHistory_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.ImageLocation = previousCaptures[CaptureHistory.SelectedIndices[0]];

            if (CaptureHistory.SelectedItems.Count > 1)
            {
                copyToolStripMenuItem.Visible = true;
                viewToolStripMenuItem.Visible = false;
                editToolStripMenuItem.Visible = false;
                renameToolStripMenuItem.Visible = false;
                sepToolStripMenuItem.Visible = false;
            }
            else
            {
                copyToolStripMenuItem.Visible = true;
                viewToolStripMenuItem.Visible = true;
                editToolStripMenuItem.Visible = true;
                renameToolStripMenuItem.Visible = true;
                sepToolStripMenuItem.Visible = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                if (CaptureHistory.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void CaptureHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (CaptureHistory.SelectedIndices[0] == 0)
                {
                    return;
                }

                pictureBox1.ImageLocation = previousCaptures[CaptureHistory.SelectedIndices[0] - 1];
            }

            if (e.KeyCode == Keys.Down)
            {
                if (CaptureHistory.SelectedIndices[0] == CaptureHistory.Items.Count - 1)
                {
                    return;
                }

                pictureBox1.ImageLocation = previousCaptures[CaptureHistory.SelectedIndices[0] + 1];
            }
        }

        private void CaptureHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = CaptureHistory.SelectedIndices[0];

            if (index != ListBox.NoMatches)
            {
                Process.Start(previousCaptures[index]);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = CaptureHistory.SelectedIndices[0];

            if (index != ListBox.NoMatches)
            {

                using (RenameFileForm rename = new RenameFileForm(CaptureHistory.Items[index].Text, previousCaptures[index]))
                {
                    if (rename.ShowDialog() == DialogResult.OK)
                    {
                        previousCaptures[index] = rename.newPath;
                        pictureBox1.ImageLocation = previousCaptures[index];
                        CaptureHistory.Items[index].Text = rename.newName;
                    }
                }
            }
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = CaptureHistory.SelectedIndices[0];

            if (index != ListBox.NoMatches)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(previousCaptures[index])
                {
                    Verb = "edit"
                };

                var process = Process.Start(startInfo);
                await Task.Run(() => process.WaitForExit());

                //Refresh image.
                pictureBox1.ImageLocation = pictureBox1.ImageLocation;
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = CaptureHistory.SelectedIndices[0];

            if (index != ListBox.NoMatches)
            {
                Process.Start(previousCaptures[index]);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringCollection paths = new StringCollection();

            foreach (ListViewItem selecteditem in CaptureHistory.SelectedItems)
            {
                paths.Add(previousCaptures[CaptureHistory.Items.IndexOf(selecteditem)]);
            }

            Clipboard.SetFileDropList(paths);
        }

        private void SettingsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SettingsForm settings = new SettingsForm())
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(pictureBox1.ImageLocation);
        }

        private void CaptureHistory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Process.Start(SavePathLocation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SettingsForm settings = new SettingsForm())
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}