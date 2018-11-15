using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotForTesting
{
    public partial class ImageEditform : Form
    {
        bool draw = false;
        bool rectangle = false;
        bool text = true;
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        private Point? _Previous = null;
        bool start = false;
        public string imageLocation;
        Pen selPen = new Pen(Color.Red);
        int i = 0;

        Stack<string> undoHistory = new Stack<string>();
        List<string> imageHistory = new List<string>();


        int mouseX, mouseY;

        public ImageEditform(string imageLocation)
        {
            this.imageLocation = imageLocation;
            InitializeComponent();
            pictureBox1.ImageLocation = imageLocation;
            selPen.MiterLimit = selPen.MiterLimit / 12;
            selPen.LineJoin = LineJoin.Round;
            selPen.StartCap = LineCap.Round;
            selPen.EndCap = LineCap.Round;
            selPen.Width = 3;
            WindowState = FormWindowState.Maximized;
            if (Cursor.Position.X > Screen.AllScreens[0].Bounds.Left && Cursor.Position.X < Screen.AllScreens[0].Bounds.Right)
            {
                ShowOnScreen(0);
            }
            else
            {
                ShowOnScreen(1);
            }

            //BoxRadio.Checked = true;
        }

        void ShowOnScreen(int screenNumber)
        {
            Screen[] screens = Screen.AllScreens;

            if (screenNumber >= 0 && screenNumber < screens.Length)
            {
                bool maximised = false;
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    maximised = true;
                }
                Location = screens[screenNumber].WorkingArea.Location;
                if (maximised)
                {
                    WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawRadio.Checked)
            {
                _Previous = e.Location;

                AddToHistory();
            }

            if (BoxRadio.Checked)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    AddToHistory();
                    //starts coordinates for rectangle
                    selectX = e.X;
                    selectY = e.Y;
                    selPen.DashStyle = DashStyle.Solid;
                }

                //start control variable for draw rectangle
                start = true;
            }

            if (TextRadio.Checked)
            {
                AddToHistory();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawRadio.Checked)
            {
                if (_Previous != null)
                {
                    if (pictureBox1.Image == null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.White);
                        }
                        pictureBox1.Image = bmp;
                    }
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(selPen, _Previous.Value, e.Location);
                    }
                    pictureBox1.Invalidate();
                    _Previous = e.Location;
                }
            }

            if (BoxRadio.Checked)
            {
                if (start)
                {
                    //refresh picture box
                    pictureBox1.Refresh();

                    //set corner square to mouse coordinates
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;

                    selPen.Width = 3;
                    pictureBox1.CreateGraphics().DrawRectangle(selPen,
                        selectX, selectY, selectWidth, selectHeight);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawRadio.Checked)
            {
                _Previous = null;
            }

            if (BoxRadio.Checked)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = bmp;
                }

                //same functionality when mouse is over
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //pictureBox1.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    pictureBox1.CreateGraphics().DrawRectangle(selPen, selectX,
                        selectY, selectWidth, selectHeight);

                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawRectangle(selPen, selectX,
                    selectY, selectWidth, selectHeight);
                    }
                    pictureBox1.Invalidate();
                    start = false;
                }
            }

            if (TextRadio.Checked)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = bmp;
                }

                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                {
                    using (Font arialFont = new Font("Arial", 12))
                    {
                        graphics.DrawString(textBox1.Text, arialFont, Brushes.Red, e.X, e.Y);
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Common.SaveBitmap(new Bitmap(pictureBox1.Image), imageLocation);
            DialogResult = DialogResult.OK;
            DeleteHistory();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (undoHistory.Count > 0)
            {
                var image = undoHistory.Pop();
                pictureBox1.ImageLocation = image;

                if (undoHistory.Count == 0)
                {
                    UndoButton.Enabled = false;
                    SaveButton.Enabled = false;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AddToHistory()
        {
            UndoButton.Enabled = true;
            SaveButton.Enabled = true;

            var location = $"C:\\Users\\jelani.henry\\Documents\\Screenshot Testing Tool\\tmp{i++}.jpg";
            undoHistory.Push(location);
            imageHistory.Add(location);
            Common.SaveBitmap(new Bitmap(pictureBox1.Image), location);
            //pictureBox1.Image.Save(location, ImageFormat.Jpeg);
        }

        private void ImageEditform_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteHistory();
        }

        private void TextRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (TextRadio.Checked)
            {
                textBox1.Show();
            }
            else
            {
                textBox1.Hide();
            }
        }

        public void DeleteHistory()
        {
            foreach (var item in imageHistory)
            {
                if (File.Exists(item))
                {
                    File.Delete(item);
                }
            }
        }
    }
}
