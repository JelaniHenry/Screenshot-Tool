namespace ScreenshotApp
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
            this.Filename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CaptureHistory = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.systemTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.systemTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Filename
            // 
            this.Filename.Location = new System.Drawing.Point(15, 27);
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(385, 20);
            this.Filename.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filename:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(15, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 249);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(21, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CaptureHistory
            // 
            this.CaptureHistory.AutoArrange = false;
            this.CaptureHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File});
            this.CaptureHistory.FullRowSelect = true;
            this.CaptureHistory.HideSelection = false;
            this.CaptureHistory.Location = new System.Drawing.Point(420, 12);
            this.CaptureHistory.Name = "CaptureHistory";
            this.CaptureHistory.Size = new System.Drawing.Size(182, 300);
            this.CaptureHistory.TabIndex = 21;
            this.CaptureHistory.UseCompatibleStateImageBehavior = false;
            this.CaptureHistory.View = System.Windows.Forms.View.Details;
            this.CaptureHistory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.CaptureHistory_ColumnClick);
            this.CaptureHistory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CaptureHistory_ItemDrag);
            this.CaptureHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureHistory_KeyDown);
            this.CaptureHistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CaptureHistory_MouseClick);
            this.CaptureHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CaptureHistory_MouseDoubleClick);
            // 
            // File
            // 
            this.File.Text = "Screenshot History";
            this.File.Width = 178;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.sepToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 98);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = global::ScreenshotForTesting.Properties.Resources.document__4_;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.viewToolStripMenuItem.Text = "Open";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // sepToolStripMenuItem
            // 
            this.sepToolStripMenuItem.Name = "sepToolStripMenuItem";
            this.sepToolStripMenuItem.Size = new System.Drawing.Size(114, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::ScreenshotForTesting.Properties.Resources.file;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::ScreenshotForTesting.Properties.Resources.edit;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::ScreenshotForTesting.Properties.Resources.palette;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Image = global::ScreenshotForTesting.Properties.Resources.settings__2_;
            this.button1.Location = new System.Drawing.Point(15, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 24);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Image = global::ScreenshotForTesting.Properties.Resources.document__4_;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.previewToolStripMenuItem.Text = "View";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // systemTray
            // 
            this.systemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTray.Icon")));
            this.systemTray.Text = "System Tray";
            this.systemTray.Visible = true;
            this.systemTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.systemTray_MouseClick);
            // 
            // systemTrayMenu
            // 
            this.systemTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayUIToolStripMenuItem,
            this.closeApplicationToolStripMenuItem});
            this.systemTrayMenu.Name = "systemTrayMenu";
            this.systemTrayMenu.Size = new System.Drawing.Size(168, 48);
            // 
            // displayUIToolStripMenuItem
            // 
            this.displayUIToolStripMenuItem.Name = "displayUIToolStripMenuItem";
            this.displayUIToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.displayUIToolStripMenuItem.Text = "Display UI";
            this.displayUIToolStripMenuItem.Click += new System.EventHandler(this.displayUIToolStripMenuItem_Click);
            // 
            // closeApplicationToolStripMenuItem
            // 
            this.closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
            this.closeApplicationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeApplicationToolStripMenuItem.Text = "Close Application";
            this.closeApplicationToolStripMenuItem.Click += new System.EventHandler(this.closeApplicationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CaptureHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Filename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screenshot Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.systemTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Filename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView CaptureHistory;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sepToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon systemTray;
        private System.Windows.Forms.ContextMenuStrip systemTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem displayUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeApplicationToolStripMenuItem;
    }
}