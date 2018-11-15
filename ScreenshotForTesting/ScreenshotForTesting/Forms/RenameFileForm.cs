using ScreenshotForTesting.Forms;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScreenshotForTesting
{
    public partial class RenameFileForm : Form
    {
        string fileName;
        string fullPath;

        public string newPath;
        public string newName;

        public RenameFileForm(string fileName, string fullPath)
        {
            InitializeComponent();

            this.fileName = fileName;
            this.fullPath = fullPath;
            MaximizeBox = false;

            ActiveControl = textBox1;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                newName = textBox1.Text;

                if (newName == "")
                {
                    MessageBox.Show("Please enter a file name.", "File Name Is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                newPath = fullPath.Replace(fileName + ".jpg", textBox1.Text + ".jpg");

                if (File.Exists(newPath))
                {
                    using (FileExistsForm fileForm = new FileExistsForm(newName))
                    {
                        fileForm.ShowDialog();

                        if (fileForm.DialogResult == DialogResult.Cancel)
                        {
                            return;
                        }

                        if (!fileForm.overwrite)
                        {
                            return;
                        }

                        File.Delete(newPath);
                    }
                }

                File.Move(fullPath, newPath);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitBtn_Click(null, null);
            }
        }
    }
}