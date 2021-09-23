using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingStudio
{
    public partial class SaveFile : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public string FileName;
        public string Code;
        public string Diff;
        public string FilePath;
        public string Link;
        public string LastPath;
        public SaveFile()
        {
            InitializeComponent();
            LoadTree();
            
        }
        void LoadTree()
        {
            treeView1.Nodes.Clear();  
            string path = Directory.GetCurrentDirectory() + @"\Coding Studio\Codes";

            string[] directories = Directory.GetDirectories(path);
            foreach (string k in directories)
            {
                DirectoryInfo DI = new DirectoryInfo(k);
                TreeNode n = treeView1.Nodes.Add(DI.Name);
                n.Tag = DI.FullName;
                LoadDirectories(n, DI.FullName);
            }
        }
        void LoadDirectories(TreeNode root, string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string k in directories)
            {
                DirectoryInfo DI = new DirectoryInfo(k);
                TreeNode n = root.Nodes.Add(DI.Name);
                n.Tag = DI.FullName;
                LoadDirectories(n, DI.FullName);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
                FilePath = (string)treeView1.SelectedNode.Tag + "\\" + txtName.Text + ".cpp";
            else
                FilePath = Directory.GetCurrentDirectory() + "\\Coding Studio\\Codes\\" + txtName.Text + ".cpp";

            if (!String.IsNullOrEmpty(txtName.Text))
                if (!String.IsNullOrEmpty(txtCode.Text))
                    if (!String.IsNullOrEmpty(txtDiff.Text))
                        if (FileName != txtName.Text || Code != txtCode.Text || Diff != txtDiff.Text || Link != txtLink.Text || LastPath != FilePath)
                        {
                            FileInfo FI = new FileInfo(FilePath);
                            if (!FI.Exists)
                            {
                                FileName = txtName.Text;
                                Code = txtCode.Text;
                                Diff = txtDiff.Text;
                                Link = txtLink.Text;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                DialogResult ans = DialogResult.None;

                                if (FileName != txtName.Text)
                                    ans = MessageBox.Show("This file already exist, would you like to replace it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                else
                                    ans = DialogResult.Yes;

                                if (ans == DialogResult.Yes)
                                {
                                    FileName = txtName.Text;
                                    Code = txtCode.Text;
                                    Diff = txtDiff.Text;
                                    Link = txtLink.Text;
                                    this.DialogResult = DialogResult.OK;
                                }

                            }
                        }
        }

        private void SaveFile_Load(object sender, EventArgs e)
        {
            txtName.Text = FileName;
            txtCode.Text = Code;
            txtDiff.Text = Diff;
            txtLink.Text = Link;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new EditDirectory()).ShowDialog();
            LoadTree();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
