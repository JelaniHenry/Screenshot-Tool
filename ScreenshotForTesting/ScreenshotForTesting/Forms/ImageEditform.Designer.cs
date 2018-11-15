namespace ScreenshotForTesting
{
    partial class ImageEditform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditform));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.DrawRadio = new System.Windows.Forms.RadioButton();
            this.BoxRadio = new System.Windows.Forms.RadioButton();
            this.TextRadio = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 599);
            this.panel1.TabIndex = 5;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(590, 6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UndoButton.Enabled = false;
            this.UndoButton.Location = new System.Drawing.Point(509, 6);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 7;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // DrawRadio
            // 
            this.DrawRadio.AutoSize = true;
            this.DrawRadio.Location = new System.Drawing.Point(61, 9);
            this.DrawRadio.Name = "DrawRadio";
            this.DrawRadio.Size = new System.Drawing.Size(50, 17);
            this.DrawRadio.TabIndex = 8;
            this.DrawRadio.Text = "Draw";
            this.DrawRadio.UseVisualStyleBackColor = true;
            // 
            // BoxRadio
            // 
            this.BoxRadio.AutoSize = true;
            this.BoxRadio.Location = new System.Drawing.Point(12, 9);
            this.BoxRadio.Name = "BoxRadio";
            this.BoxRadio.Size = new System.Drawing.Size(43, 17);
            this.BoxRadio.TabIndex = 9;
            this.BoxRadio.Text = "Box";
            this.BoxRadio.UseVisualStyleBackColor = true;
            // 
            // TextRadio
            // 
            this.TextRadio.AutoSize = true;
            this.TextRadio.Location = new System.Drawing.Point(118, 9);
            this.TextRadio.Name = "TextRadio";
            this.TextRadio.Size = new System.Drawing.Size(46, 17);
            this.TextRadio.TabIndex = 10;
            this.TextRadio.Text = "Text";
            this.TextRadio.UseVisualStyleBackColor = true;
            this.TextRadio.CheckedChanged += new System.EventHandler(this.TextRadio_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ImageEditform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 643);
            this.Controls.Add(this.TextRadio);
            this.Controls.Add(this.BoxRadio);
            this.Controls.Add(this.DrawRadio);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageEditform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview/Edit Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageEditform_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.RadioButton DrawRadio;
        private System.Windows.Forms.RadioButton BoxRadio;
        private System.Windows.Forms.RadioButton TextRadio;
    }
}