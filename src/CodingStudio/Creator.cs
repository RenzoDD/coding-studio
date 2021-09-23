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
    public partial class Creator : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Creator()
        {
            InitializeComponent();
        }
        
        List<string> directories = new List<string>();
        int value = 0;
        string path_found = "";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                (new Task(() =>
                {
                    Buttonenabled = false;
                    string root = @"C:\";
                    directories = Directory.GetDirectories(root).ToList();


                    for (int i = 0; i < directories.Count; i++)
                    {
                        try
                        {
                            value++;
                            directories.AddRange(Directory.GetDirectories(directories[i]).ToList());
                            path_found = directories[i];
                            if (stop || directories[i].Contains("MinGW64"))
                            { stop = false; break; }
                        }
                        catch (Exception ex) { }
                    }
                    End();
                    Buttonenabled = true;
                })).Start();
            }
            else
            {
                stop = true;
                btnSearch.Text = "Search";
            }
        }
        private void Download_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/mingw-w64/");
        }
        private void btnCompile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog obj = new FolderBrowserDialog();

            if (obj.ShowDialog() == DialogResult.OK)
            { path_found = obj.SelectedPath; End(); }
        }
        string version = "";

        private void End()
        {
            if (path_found != "")
            {
                FileInfo FI = new FileInfo(path_found + @"\bin\g++.exe");
                if (!FI.Exists)
                {
                    var ans = MessageBox.Show("I couldn't find a compiler, please check the path", "Compiler not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (ans == DialogResult.OK)
                        path_found = "";
                }
                else
                {
                    var ans = MessageBox.Show("Are you sure you want to use this route as a compiler?\n" + path_found + @"\bin\g++.exe", "Compiler found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans == DialogResult.Yes)
                    {
                        


                        DirectoryInfo DI = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Coding Studio");
                        DI.Create();
                        DI.Attributes |= FileAttributes.Hidden;



                        DirectoryInfo DI1 = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Coding Studio\Codes");
                        DI1.Create();
                        StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
                        sw.WriteLine(path_found + @"\bin");
                        sw.WriteLine(path_found + @"\bin\g++.exe");
                        if (version == "")
                            sw.WriteLine(0);
                        else
                            sw.WriteLine(version);
                        sw.Close();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        path_found = "";
                    }
                    
                }
            }
        }
        bool Buttonenabled = true;
        bool stop = false;
        private void clock_Tick(object sender, EventArgs e)
        {
            lblPath.Text = "    Path: " + path_found;
            btnCompile.Enabled = Buttonenabled;
            btnSearch.Text = (Buttonenabled) ? "Search" : "Stop";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rb11_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            version = (string)rb.Tag;
            if (version == null)
                version = "";

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
