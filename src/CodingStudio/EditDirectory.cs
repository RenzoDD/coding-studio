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
    public partial class EditDirectory : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public EditDirectory()
        {
            InitializeComponent();
            LoadTree();
        }
        public void LoadTree()
        {
            treeView1.Nodes.Clear();
            string[] subdirectories = Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\Coding Studio\Codes");
            foreach (string i in subdirectories)
            {
                DirectoryInfo DI = new DirectoryInfo(i);
                TreeNode tds = treeView1.Nodes.Add(DI.Name);
                tds.Tag = DI.FullName; ;
                LoadDirectories(tds, DI.FullName);
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string path = ((treeView1.SelectedNode == null) ? Directory.GetCurrentDirectory() + @"\Coding Studio\Codes" : (string)treeView1.SelectedNode.Tag) + "\\" + txtName.Text;
            DirectoryInfo DI = new DirectoryInfo(path);
            if (!DI.Exists)
            {
                DI.Create();
                LoadTree();
            }
            else
                MessageBox.Show("This directory already exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string path = (string)treeView1.SelectedNode.Tag;
                DirectoryInfo DI = new DirectoryInfo(path);
                DialogResult ans = DialogResult.Yes;
                if (DI.GetFiles().Count() + DI.GetDirectories().Count() != 0)
                    ans = MessageBox.Show("This folder has content. Are you sure you want to delete it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes)
                {
                    DI.Delete(true);
                    LoadTree();
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string path = (string)treeView1.SelectedNode.Tag;
                DirectoryInfo DI = new DirectoryInfo(path);
                string dest = DI.FullName.Substring(0, DI.FullName.Length - DI.Name.Length) + txtName.Text;
                DirectoryInfo NEW = new DirectoryInfo(dest);
                if (!NEW.Exists)
                {
                    DI.MoveTo(dest);
                    LoadTree();
                }
                else
                    MessageBox.Show("This directory already exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string path = (string)treeView1.SelectedNode.Tag;
                DirectoryInfo d = new DirectoryInfo(path);
                FolderBrowserDialog obj = new FolderBrowserDialog();
                if (obj.ShowDialog() == DialogResult.OK)
                {
                    Copy(path, obj.SelectedPath + @"\" + d.Name);
                    MessageBox.Show("Done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
                txtName.Text = treeView1.SelectedNode.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                ChooseDirectory obj = new ChooseDirectory();
                var a = obj.ShowDialog();

                if (a == DialogResult.OK)
                {
                    string path = (string)treeView1.SelectedNode.Tag;
                    DirectoryInfo dir = new DirectoryInfo(obj.PATH);
                    DirectoryInfo dir1 = new DirectoryInfo(path);
                    DirectoryInfo A = new DirectoryInfo(obj.PATH + "\\" + dir1.Name);
                    if (!A.Exists)
                    {
                        try
                        {
                            dir1.MoveTo(A.FullName);
                            LoadTree();
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("This directory already exist");
                    }
                }
            }
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
