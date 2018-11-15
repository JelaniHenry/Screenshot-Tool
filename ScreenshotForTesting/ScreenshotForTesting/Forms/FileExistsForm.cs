using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotForTesting.Forms
{
    public partial class FileExistsForm : Form
    {
        public bool overwrite;

        public FileExistsForm(string fileName)
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            overwrite = true;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            overwrite = false;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
