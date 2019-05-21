using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ScreenshotForTesting
{
    public partial class SnippingForm : Form
    {
        enum Position
        {
            BottomRight,
            BottomLeft,
            TopRight,
            TopLeft
        }

        Position position;
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;

        public Bitmap CaptureFromSnip;

        bool start = false;

        public SnippingForm()
        {
            InitializeComponent();

        }

        private void SnippingForm_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

            int activeScreen;

            Hide();

            Thread.Sleep(250);

            if (Cursor.Position.X > Screen.AllScreens[0].Bounds.Left && Cursor.Position.X < Screen.AllScreens[0].Bounds.Right)
            {
                activeScreen = 0;
                ShowOnScreen(0);
            }
            else
            {
                activeScreen = 1;
                ShowOnScreen(1);
            }

            //Create the Bitmap
            Bitmap printscreen = new Bitmap(Screen.AllScreens[activeScreen].Bounds.Width,
                Screen.AllScreens[activeScreen].Bounds.Height);

            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);

            //Copy Image from the screen
            graphics.CopyFromScreen(Screen.AllScreens[activeScreen].Bounds.X, Screen.AllScreens[activeScreen].Bounds.Y, 0, 0, printscreen.Size);

            //Create a temporal memory stream for the image
            using (MemoryStream s = new MemoryStream())
            {
                //save graphic variable into memory
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new Size(Width, Height);
                //set the picture box with temporary stream
                pictureBox1.Image = Image.FromStream(s);
            }

            //Show Form
            Show();
            Activate();

            //Cross Cursor
            Cursor = Cursors.Cross;
        }

        private void ShowOnScreen(int screenNumber)
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;

            //validate if right-click was trigger
            if (start)
            {
                //refresh picture box
                pictureBox1.Refresh();

                if (e.X > selectX && e.Y > selectY)
                {
                    //Top left to bottom right
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                    selectX, selectY, selectWidth, selectHeight);

                    position = Position.TopLeft;
                }
                else if (e.X < selectX && e.Y < selectY)
                {
                    //bottom right to top left
                    selectWidth = selectX - e.X;
                    selectHeight = selectY - e.Y;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX - selectWidth, selectY - selectHeight, selectWidth, selectHeight);

                    position = Position.BottomRight;
                }

                else if (e.X > selectX && e.Y < selectY)
                {
                    //bottom left to top right
                    selectWidth = e.X - selectX;
                    selectHeight = selectY - e.Y;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX, selectY - selectHeight, selectWidth, selectHeight);

                    position = Position.BottomLeft;
                }

                else if (e.X < selectX && e.Y > selectY)
                {
                    //top right to bottem left
                    selectWidth = selectX - e.X;
                    selectHeight = e.Y - selectY;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX - selectWidth, selectY, selectWidth, selectHeight);

                    position = Position.TopRight;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //starts coordinates for rectangle
                selectX = e.X;
                selectY = e.Y;
                selectPen = new Pen(Color.Red, 1);
                selectPen.DashStyle = DashStyle.Solid;

                button1.Hide();

                //refresh picture box
                pictureBox1.Refresh();

                //start control variable for draw rectangle
                start = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //validate if there is image
            if (pictureBox1.Image == null)
                return;

            //same functionality when mouse is over
            if (e.Button == MouseButtons.Left)
            {
                pictureBox1.Refresh();

                if (e.X > selectX && e.Y > selectY)
                {
                    //Top left to bottom right
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                    selectX, selectY, selectWidth, selectHeight);
                }
                else if (e.X < selectX && e.Y < selectY)
                {
                    //bottom right to top left
                    selectWidth = selectX - e.X;
                    selectHeight = selectY - e.Y;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX - selectWidth, selectY - selectHeight, selectWidth, selectHeight);
                }

                else if (e.X > selectX && e.Y < selectY)
                {
                    //bottom left to top right
                    selectWidth = e.X - selectX;
                    selectHeight = selectY - e.Y;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX, selectY - selectHeight, selectWidth, selectHeight);
                }

                else if (e.X < selectX && e.Y > selectY)
                {
                    //top right to bottem left
                    selectWidth = selectX - e.X;
                    selectHeight = e.Y - selectY;

                    pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                       selectX - selectWidth, selectY, selectWidth, selectHeight);
                }
            }

            start = false;

            //function save image to clipboard
            SaveToClipboard();
        }

        private void SaveToClipboard()
        {
            //validate if something selected
            if (selectWidth > 0)
            {
                try
                {
                    Rectangle rect;

                    if (position == Position.TopLeft)
                    {
                        rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                    }

                    else if (position == Position.BottomRight)
                    {
                        rect = new Rectangle(selectX - selectWidth, selectY - selectHeight, selectWidth, selectHeight);
                    }

                    else if (position == Position.BottomLeft)
                    {
                        rect = new Rectangle(selectX, selectY - selectHeight, selectWidth, selectHeight);
                    }

                    else if (position == Position.TopRight)
                    {
                        rect = new Rectangle(selectX - selectWidth, selectY, selectWidth, selectHeight);
                    }

                    else
                    {
                        rect = new Rectangle(selectX, selectY, selectWidth, selectHeight); ;
                    }

                    //create bitmap with original dimensions
                    Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                    //create bitmap with selected dimensions
                    Bitmap _img = new Bitmap(selectWidth, selectHeight);
                    //create graphic variable
                    Graphics g = Graphics.FromImage(_img);

                    //set graphic attributes
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                    //insert image stream into clipboard
                    Clipboard.SetImage(_img);
                    CaptureFromSnip = _img;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception e) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}