namespace CodingStudio
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb14 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtCompiler = new System.Windows.Forms.TextBox();
            this.btnFindOther = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.btnClearCodes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb14);
            this.groupBox1.Controls.Add(this.rb11);
            this.groupBox1.Controls.Add(this.rbDefault);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(203, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(273, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version";
            // 
            // rb14
            // 
            this.rb14.AutoSize = true;
            this.rb14.Location = new System.Drawing.Point(190, 26);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(79, 27);
            this.rb14.TabIndex = 1;
            this.rb14.Text = "C++ 14";
            this.rb14.UseVisualStyleBackColor = true;
            // 
            // rb11
            // 
            this.rb11.AutoSize = true;
            this.rb11.Location = new System.Drawing.Point(103, 28);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(79, 27);
            this.rb11.TabIndex = 1;
            this.rb11.Text = "C++ 11";
            this.rb11.UseVisualStyleBackColor = true;
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Location = new System.Drawing.Point(7, 26);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(75, 27);
            this.rbDefault.TabIndex = 0;
            this.rbDefault.Text = "Default";
            this.rbDefault.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Controls.Add(this.txtCompiler);
            this.groupBox2.Controls.Add(this.btnFindOther);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(14, 115);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(462, 91);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compiler";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Arial Narrow", 13F);
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(99, 51);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(142, 28);
            this.btnCheck.TabIndex = 89;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtCompiler
            // 
            this.txtCompiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtCompiler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompiler.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCompiler.ForeColor = System.Drawing.Color.White;
            this.txtCompiler.Location = new System.Drawing.Point(7, 26);
            this.txtCompiler.MaxLength = 4;
            this.txtCompiler.Name = "txtCompiler";
            this.txtCompiler.ReadOnly = true;
            this.txtCompiler.Size = new System.Drawing.Size(448, 16);
            this.txtCompiler.TabIndex = 89;
            this.txtCompiler.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFindOther
            // 
            this.btnFindOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFindOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindOther.FlatAppearance.BorderSize = 0;
            this.btnFindOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnFindOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindOther.Font = new System.Drawing.Font("Arial Narrow", 13F);
            this.btnFindOther.ForeColor = System.Drawing.Color.White;
            this.btnFindOther.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindOther.Location = new System.Drawing.Point(247, 51);
            this.btnFindOther.Name = "btnFindOther";
            this.btnFindOther.Size = new System.Drawing.Size(142, 28);
            this.btnFindOther.TabIndex = 88;
            this.btnFindOther.Text = "Find Another";
            this.btnFindOther.UseVisualStyleBackColor = false;
            this.btnFindOther.Click += new System.EventHandler(this.btnFindOther_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOptimize);
            this.groupBox3.Controls.Add(this.btnClearCodes);
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(14, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(181, 95);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Codes";
            // 
            // btnOptimize
            // 
            this.btnOptimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOptimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptimize.FlatAppearance.BorderSize = 0;
            this.btnOptimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnOptimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptimize.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.btnOptimize.ForeColor = System.Drawing.Color.White;
            this.btnOptimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptimize.Location = new System.Drawing.Point(7, 57);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(167, 28);
            this.btnOptimize.TabIndex = 92;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.UseVisualStyleBackColor = false;
            this.btnOptimize.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClearCodes
            // 
            this.btnClearCodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClearCodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCodes.FlatAppearance.BorderSize = 0;
            this.btnClearCodes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClearCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCodes.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.btnClearCodes.ForeColor = System.Drawing.Color.White;
            this.btnClearCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearCodes.Location = new System.Drawing.Point(7, 23);
            this.btnClearCodes.Name = "btnClearCodes";
            this.btnClearCodes.Size = new System.Drawing.Size(167, 28);
            this.btnClearCodes.TabIndex = 91;
            this.btnClearCodes.Text = "Delete All";
            this.btnClearCodes.UseVisualStyleBackColor = false;
            this.btnClearCodes.Click += new System.EventHandler(this.btnClearCodes_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 224);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
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
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(451, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 38);
            this.button2.TabIndex = 90;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 24F);
            this.label1.Location = new System.Drawing.Point(272, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(491, 224);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb14;
        private System.Windows.Forms.RadioButton rb11;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCompiler;
        private System.Windows.Forms.Button btnFindOther;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearCodes;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}