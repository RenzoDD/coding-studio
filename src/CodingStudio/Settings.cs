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
    public partial class Settings : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Settings()
        {
            InitializeComponent();
        }
          
        private void Settings_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
            sr.ReadLine();

            txtCompiler.Text = sr.ReadLine();

            string version = sr.ReadLine();
            rbDefault.Checked = version == "0";
            rb11.Checked = version == "11";
            rb14.Checked = version == "14";

            rbDefault.CheckedChanged += ChangeVersion;
            rb11.CheckedChanged += ChangeVersion;
            rb14.CheckedChanged += ChangeVersion;

            sr.Close();

        }

        private void ChangeVersion(object sender, EventArgs e)
        {
            try
            {
                if ((rbDefault.Checked || rb11.Checked || rb14.Checked) != false)
                {
                    StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
                    string compiler_directory = sr.ReadLine();
                    string compiler_file = sr.ReadLine();
                    sr.Close();
                    StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
                    sw.WriteLine(compiler_directory);
                    sw.WriteLine(compiler_file);
                    if (rbDefault.Checked)
                        sw.WriteLine("0");
                    if (rb11.Checked)
                        sw.WriteLine("11");
                    if (rb14.Checked)
                        sw.WriteLine("14");
                    sw.Close();
                }
            }
            catch { }
        }


        private void btnClearCodes_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Are you sure you want to delete all your codes?", "Please wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ans == DialogResult.Yes)
            {
                DirectoryInfo DI = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Coding Studio\Codes");
                FileInfo[] files = DI.GetFiles();
                foreach (FileInfo s in files)
                    s.Delete();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo DI = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Coding Studio\Codes");
            FileInfo[] files = DI.GetFiles("*.exe");
            foreach (FileInfo s in files)
                s.Delete();
            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            FileInfo FI = new FileInfo(txtCompiler.Text);
            if (FI.Exists)
                MessageBox.Show("Compiler found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Compiler not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnFindOther_Click(object sender, EventArgs e)
        {
            if ( (new Creator()).ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
                sr.ReadLine();

                txtCompiler.Text = sr.ReadLine();

                rbDefault.Checked = rb11.Checked = rb14.Checked = false;
                
                string version = sr.ReadLine(); sr.Close();
                rbDefault.Checked = version == "0";
                rb11.Checked = version == "11";
                rb14.Checked = version == "14";


                
                
            }

        }

        private void rb11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
