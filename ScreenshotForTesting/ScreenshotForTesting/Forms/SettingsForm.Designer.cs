namespace ScreenshotForTesting.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.ScreenCapMod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ScreenCapKey = new System.Windows.Forms.ComboBox();
            this.SnipKey = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SnipMod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Window Capture Shortcut:";
            // 
            // ScreenCapMod
            // 
            this.ScreenCapMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenCapMod.FormattingEnabled = true;
            this.ScreenCapMod.Items.AddRange(new object[] {
            "Ctrl",
            "Ctrl + Alt"});
            this.ScreenCapMod.Location = new System.Drawing.Point(23, 44);
            this.ScreenCapMod.Name = "ScreenCapMod";
            this.ScreenCapMod.Size = new System.Drawing.Size(62, 21);
            this.ScreenCapMod.TabIndex = 2;
            this.ScreenCapMod.SelectedValueChanged += new System.EventHandler(this.ScreenCapMod_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            // 
            // ScreenCapKey
            // 
            this.ScreenCapKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenCapKey.FormattingEnabled = true;
            this.ScreenCapKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.ScreenCapKey.Location = new System.Drawing.Point(110, 44);
            this.ScreenCapKey.Name = "ScreenCapKey";
            this.ScreenCapKey.Size = new System.Drawing.Size(40, 21);
            this.ScreenCapKey.TabIndex = 7;
            this.ScreenCapKey.SelectedValueChanged += new System.EventHandler(this.ScreenCapKey_SelectedValueChanged);
            // 
            // SnipKey
            // 
            this.SnipKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SnipKey.FormattingEnabled = true;
            this.SnipKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.SnipKey.Location = new System.Drawing.Point(110, 96);
            this.SnipKey.Name = "SnipKey";
            this.SnipKey.Size = new System.Drawing.Size(40, 21);
            this.SnipKey.TabIndex = 11;
            this.SnipKey.SelectedValueChanged += new System.EventHandler(this.SnipKey_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "+";
            // 
            // SnipMod
            // 
            this.SnipMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SnipMod.FormattingEnabled = true;
            this.SnipMod.Items.AddRange(new object[] {
            "Ctrl",
            "Ctrl + Alt"});
            this.SnipMod.Location = new System.Drawing.Point(23, 96);
            this.SnipMod.Name = "SnipMod";
            this.SnipMod.Size = new System.Drawing.Size(62, 21);
            this.SnipMod.TabIndex = 9;
            this.SnipMod.SelectedValueChanged += new System.EventHandler(this.SnipMod_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Snipping Tool Shortcut:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ScreenCapMod);
            this.groupBox1.Controls.Add(this.SnipKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SnipMod);
            this.groupBox1.Controls.Add(this.ScreenCapKey);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 140);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkeys";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(567, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(210, 28);
            this.SavePath.Name = "SavePath";
            this.SavePath.ReadOnly = true;
            this.SavePath.Size = new System.Drawing.Size(351, 20);
            this.SavePath.TabIndex = 14;
            this.SavePath.TextChanged += new System.EventHandler(this.SavePath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Save Path:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(210, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Preview After Screenshot Taken";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 162);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ScreenCapMod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ScreenCapKey;
        private System.Windows.Forms.ComboBox SnipKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SnipMod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}