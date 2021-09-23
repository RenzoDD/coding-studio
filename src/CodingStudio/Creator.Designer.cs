namespace CodingStudio
{
    partial class Creator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creator));
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.rb14 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCompile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompile.FlatAppearance.BorderSize = 0;
            this.btnCompile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompile.Font = new System.Drawing.Font("Arial Narrow", 11F);
            this.btnCompile.ForeColor = System.Drawing.Color.White;
            this.btnCompile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompile.Location = new System.Drawing.Point(61, 52);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(148, 28);
            this.btnCompile.TabIndex = 79;
            this.btnCompile.Text = "I know where it is";
            this.btnCompile.UseVisualStyleBackColor = false;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial Narrow", 11F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(215, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 28);
            this.btnSearch.TabIndex = 80;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 49);
            this.label1.TabIndex = 83;
            this.label1.Text = "Do you have the MinGW64 compiler?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkLabel1.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Teal;
            this.linkLabel1.Location = new System.Drawing.Point(0, 151);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(418, 20);
            this.linkLabel1.TabIndex = 85;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Download";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Download_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblPath);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.btnCompile);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 173);
            this.panel1.TabIndex = 86;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDefault);
            this.groupBox1.Controls.Add(this.rb14);
            this.groupBox1.Controls.Add(this.rb11);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(118, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 43);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version";
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.rbDefault.ForeColor = System.Drawing.Color.White;
            this.rbDefault.Location = new System.Drawing.Point(6, 16);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(58, 21);
            this.rbDefault.TabIndex = 92;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Default";
            this.rbDefault.UseVisualStyleBackColor = true;
            this.rbDefault.CheckedChanged += new System.EventHandler(this.rb11_CheckedChanged);
            // 
            // rb14
            // 
            this.rb14.AutoSize = true;
            this.rb14.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.rb14.ForeColor = System.Drawing.Color.White;
            this.rb14.Location = new System.Drawing.Point(136, 16);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(63, 21);
            this.rb14.TabIndex = 94;
            this.rb14.Tag = "14";
            this.rb14.Text = "C++ 14";
            this.rb14.UseVisualStyleBackColor = true;
            this.rb14.CheckedChanged += new System.EventHandler(this.rb11_CheckedChanged);
            // 
            // rb11
            // 
            this.rb11.AutoSize = true;
            this.rb11.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.rb11.ForeColor = System.Drawing.Color.White;
            this.rb11.Location = new System.Drawing.Point(71, 16);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(63, 21);
            this.rb11.TabIndex = 93;
            this.rb11.Tag = "11";
            this.rb11.Text = "C++ 11";
            this.rb11.UseVisualStyleBackColor = true;
            this.rb11.CheckedChanged += new System.EventHandler(this.rb11_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(380, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 38);
            this.button2.TabIndex = 91;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lblPath
            // 
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPath.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.lblPath.ForeColor = System.Drawing.Color.White;
            this.lblPath.Location = new System.Drawing.Point(0, 132);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(418, 19);
            this.lblPath.TabIndex = 86;
            this.lblPath.Text = "    Path:";
            // 
            // clock
            // 
            this.clock.Enabled = true;
            this.clock.Interval = 1;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(420, 173);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creator";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.RadioButton rb14;
        private System.Windows.Forms.RadioButton rb11;
    }
}