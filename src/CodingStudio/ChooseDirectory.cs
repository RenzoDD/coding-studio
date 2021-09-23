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
    public partial class ChooseDirectory : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ChooseDirectory()
        {
            InitializeComponent();
            LoadTree();
            treeView1.SelectedNode = null;
        }
        public void LoadTree()
        {
            treeView1.Nodes.Clear();
            string[] subdirectories = Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\Coding Studio");
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
        public string PATH;
        private void button3_Click(object sender, EventArgs e)
        {
            PATH = (string)(treeView1.SelectedNode.Tag);
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
