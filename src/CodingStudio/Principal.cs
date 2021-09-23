using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;
using System.Net;

namespace CodingStudio
{
    public partial class Principal : Form
    {

        TextStyle Include = new TextStyle(new SolidBrush(Color.FromArgb(214, 157, 133)), null, FontStyle.Regular);
        TextStyle logical = new TextStyle(new SolidBrush(Color.Gray), null, FontStyle.Regular);
        TextStyle Macros = new TextStyle(new SolidBrush(Color.Magenta), null, FontStyle.Regular);
        TextStyle functions = new TextStyle(new SolidBrush(Color.DarkGray), null, FontStyle.Regular);
        TextStyle classes = new TextStyle(new SolidBrush(Color.Lime), null, FontStyle.Regular);
        TextStyle NombreClases = new TextStyle(new SolidBrush(Color.FromArgb(78, 201, 176)), null, FontStyle.Regular);
        TextStyle Comentario = new TextStyle(new SolidBrush(Color.FromArgb(87, 166, 74)), null, FontStyle.Regular);
        TextStyle strings = new TextStyle(new SolidBrush(Color.FromArgb(214, 157, 125)), null, FontStyle.Regular);
        TextStyle palabra_reservada = new TextStyle(new SolidBrush(Color.FromArgb(86, 156, 214)), null, FontStyle.Regular);
        TextStyle Numeros = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);

        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        
        string compiler_file;
        string compiler_directory;
        string path_current;
        string path_codes;
        string path_info;
        string path_file = "";
        string filename = "New Code";
        string difficulty = "";
        string code = "";
        bool saved = false;
        bool exist_errors = false;
        bool working = false;
        string errors = "";
        int error;
        int warning;
        string version;
        bool solved = false;

        string diffi, category, link;


        bool displaydata = false;
        int times;
        int memory;
        int exitval;
        string output;
        string input;

        Process actual_process = null;

        public Principal()
        {
            InitializeComponent();
            path_current = Directory.GetCurrentDirectory();
            path_codes = path_current + @"\Coding Studio\Codes";
            path_info = path_current + @"\Coding Studio\info.ini";
            StreamReader sr = new StreamReader(path_info);
            compiler_directory = sr.ReadLine();
            compiler_file = sr.ReadLine();
            version = sr.ReadLine();
            sr.Close();

            LoadTree();
        }

        #region Utilities Functions
        void Compile()
        {
            if (actual_process != null)
            {
                if (!actual_process.HasExited)
                {
                    actual_process.Kill();
                    actual_process = null;
                }
                else
                    actual_process = null;
            }
            colorBar = Color.Orange;
            labelText = "Compiling";

            Process comp = new Process();
            comp.StartInfo.CreateNoWindow = true;
            comp.StartInfo.UseShellExecute = false;
            comp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            comp.StartInfo.RedirectStandardError = true;
            comp.StartInfo.RedirectStandardOutput = true;
            comp.StartInfo.WorkingDirectory = compiler_directory;
            comp.StartInfo.FileName = compiler_file;
            comp.StartInfo.Arguments = string.Concat('"', path_file, '"') + " -o " + string.Concat('"', (Directory.GetCurrentDirectory() + @"\Coding Studio\code.exe"), '"') + ((version == "11") ? " -Wall -Wextra -std=c++11" : (version == "14") ? " -Wall -Wextra -std=c++14" : "");
            comp.EnableRaisingEvents = true;
            comp.Start();
            errors = comp.StandardError.ReadToEnd();
            comp.WaitForExit();
            exist_errors = (errors != "");
            colorBar = Color.FromArgb(0, 122, 204);
            labelText = "Ready";
        }
        void Run()
        {
            if (actual_process != null)
            {
                if (!actual_process.HasExited)
                {
                    actual_process.Kill();
                    actual_process = null;
                }
                else
                    actual_process = null;
            }
            string exe = (Directory.GetCurrentDirectory() + @"\Coding Studio\code.exe");
            colorBar = Color.Green;
            labelText = "Running";

            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            //process.RedirectStandardError = true;
            actual_process = process;
            process.Start();
            StreamWriter myStreamWriter = process.StandardInput;
            myStreamWriter.WriteLine(input);
            myStreamWriter.Close();
            memory = (process.PagedMemorySize / 1024);
            string outlog = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            TimeSpan time = process.PrivilegedProcessorTime;
            times = (int)Math.Round(time.TotalMilliseconds, 0);
            exitval = process.ExitCode;
            output = outlog;
            displaydata = true;
            actual_process = null;
            colorBar = Color.FromArgb(0, 122, 204);
            labelText = "Ready";
        }
        void LoadErrors()
        {
            errors = errors.Replace(path_file + ":", "");

            int start = 0;
            int lenght = 0;

            error = 0;
            warning = 0;

            for (int i = 0; i < errors.Length; i++)
            {
                if (errors[i] == '\n')
                {
                    string line = errors.Substring(start, lenght);
                    if (char.IsDigit(line[0]))
                    {
                        if (line.Contains("error"))
                        {
                            string l = "";
                            string c = "";

                            foreach (char id in line)
                                if (char.IsDigit(id))
                                    l += id;
                                else
                                    break;
                            line = line.Substring(l.Length + 1, line.Length - (l.Length + 1));

                            foreach (char id in line)
                                if (char.IsDigit(id))
                                    c += id;
                                else
                                    break;
                            line = line.Substring(c.Length + 9, line.Length - (c.Length + 9));

                            errorList.Items.Add("Error | Line: " + (int.Parse(l) - 4).ToString() + " : " + line.PadRight(120, ' '));
                           
                            fastColoredTextBox1.BookmarkLine(int.Parse(l) - 5);
                            error++;
                            errorList.Items[errorList.Items.Count - 1].BackColor = Color.DarkRed;

                            btnErrors.Image = Properties.Resources.down;
                            pErrors.Height = 126;
                        }
                        else if (line.Contains("warning"))
                        {
                            string l = "";
                            string c = "";

                            foreach (char id in line)
                                if (char.IsDigit(id))
                                    l += id;
                                else
                                    break;
                            line = line.Substring(l.Length + 1, line.Length - (l.Length + 1));

                            foreach (char id in line)
                                if (char.IsDigit(id))
                                    c += id;
                                else
                                    break;

                            line = line.Substring(c.Length + 9, line.Length - (c.Length + 9));
                            
                            errorList.Items.Add("Warning | Line: " + (int.Parse(l) - 4).ToString() + " "+ line.PadRight(120, ' '));
                            warning++;
                            errorList.Items[errorList.Items.Count - 1].ForeColor = Color.Black;
                            errorList.Items[errorList.Items.Count - 1].BackColor = Color.DarkGoldenrod;
                        }
                    }
                    start = i + 1;
                    lenght = 0;
                }
                lenght++;
            }

            if (error != 0)
            {
                colorBar = Color.Red;
                labelText = "Errors: " + error + " | Warnings: " + warning;
            }
            else if (warning != 0)
            {
                colorBar = Color.DarkGoldenrod;
                labelText = "Errors: " + error + " | Warnings: " + warning;
            }
        }
        bool Save()
        {
            if (path_file == "" || path_file == (Directory.GetCurrentDirectory() + @"\Coding Studio\file.cpp"))
            { return SaveAs(); }
            try
            {
                StreamWriter sw = File.CreateText(path_file);
                sw.WriteLine("//Difficulty: " + diffi);
                sw.WriteLine("//Tags: " + category);
                sw.WriteLine("//Link: " + link);
                sw.WriteLine("//Solved: " + cbSolved.Checked.ToString());
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
                saved = true;
                LoadTree();
                return true;
            }
            catch { return false; }
        }
        bool SaveAs()
        {
            SaveFile sf = new SaveFile();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                path_file = sf.FilePath;
                filename = sf.FileName;
                category = sf.Code;
                diffi = sf.Diff;
                link = sf.Link;
                saved = false;
                Save();
                LoadTree();
                return true;
            }
            return false;
        }
        void FullScreen()
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        #endregion

        public void LoadTree()
        {
            working = true;
            treeView1.Nodes.Clear();
            string[] subdirectories = Directory.GetDirectories(path_codes);
            string[] Files = Directory.GetFiles(path_codes, "*.cpp");
            foreach (string i in subdirectories)
            {
                DirectoryInfo DI = new DirectoryInfo(i);
                TreeNode tds = treeView1.Nodes.Add(DI.Name);
                tds.ForeColor = Color.DarkCyan;
                LoadDirectories(tds, DI.FullName);
                LoadFiles(tds, DI.FullName);
            }
            foreach (string i in Files)
            {
                FileInfo fi = new FileInfo(i);
                TreeNode tds = treeView1.Nodes.Add(fi.Name.Substring(0, fi.Name.Length - 4));
                tds.Tag = fi.FullName;

                StreamReader sr = new StreamReader(fi.FullName);
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                string f = sr.ReadLine().Substring(10);
                if (char.ToUpper(f[0]) == 'F')
                    tds.ForeColor = Color.DarkGray;
                sr.Close();
            }

            working = false;
        }
        void LoadDirectories(TreeNode root, string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string k in directories)
            {
                DirectoryInfo DI = new DirectoryInfo(k);
                TreeNode n = root.Nodes.Add(DI.Name);
                n.ForeColor = Color.DarkCyan;
                LoadDirectories(n, DI.FullName);
                LoadFiles(n, DI.FullName);
            }
        }
        void LoadFiles(TreeNode root, string path)
        {
            string[] files = Directory.GetFiles(path, "*.cpp");

            foreach(string k in files)
            {
                FileInfo FI = new FileInfo(k);
                TreeNode n = root.Nodes.Add(FI.Name.Substring(0, FI.Name.Length - 4));
                
                n.Tag = FI.FullName;

                StreamReader sr = new StreamReader(FI.FullName);
                sr.ReadLine().Substring(14);
                sr.ReadLine().Substring(8);
                sr.ReadLine().Substring(8);
                string f = sr.ReadLine().Substring(10);
                if (char.ToUpper(f[0]) == 'F')
                    n.ForeColor = Color.DarkGray;
                sr.Close();
            }
        }
        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBox1.Range.ClearStyle(Comentario, strings, Include, Macros, classes, logical, functions, palabra_reservada);


            fastColoredTextBox1.Range.SetStyle(Comentario, @"//.*$", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(Comentario, @"/\*.*?\*/", RegexOptions.Singleline);
            fastColoredTextBox1.Range.SetStyle(Include, @"#include.*$", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(Macros, @"#define.*$", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(strings, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            fastColoredTextBox1.Range.SetStyle(Numeros, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b|\b0b[a-fA-F\d]+\b|\b0o[a-fA-F\d]+\b");
            fastColoredTextBox1.Range.SetStyle(Macros, @"\b(NULL|INT_MAX|INT_MIN|__DATE__|__LINE__|__FILE__|__TIME__|__cplusplus)\b", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(classes, @"\b(Random|unordered_set|unordered_multiset|unordered_map|unordered_multimap|pair|vector|set|map|array|deque|forward_list|list|stack|queue|priority_queue|multiset|multimap)\b", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(logical, @"\b(and|bitand|compl|not_eq|or_eq|xor_eq|and_eq|bitor|not|or|xor)\b", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(functions, @"\b(__gcd|toupper|tolower|time|rand|srand|binary_search|next_permutation|prev_permutation|lexicographical_compare|upper_bound|min|max|merge|lower_bound|is_sorted|shuffle|reverse|fill|generate|sort|replace|swap|count)\b", RegexOptions.Multiline);
            fastColoredTextBox1.Range.SetStyle(palabra_reservada, @"\b(thread|string|auto|const|double|float|int|short|struct|unsigned|break|continue|else|for|long|signed|switch|void|case|default|enum|goto|register|sizeof|typedef|volatile|char|do|extern|if|return|static|union|while|asm|dynamic_cast|wchar_t|true|protected|mutable|delete|throw|public|inline|const_cast|using|this|private|friend|class|typename|template|operator|false|catch|typeid|static_cast|new|explicit|bool|try|reinterpret_cast|namespace)\b", RegexOptions.Multiline);
            saved = false;
        }

        private void fastColoredTextBox1_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBox1.Range.ClearStyle(NombreClases);

            //find function declarations, highlight all of their entry into the code
            foreach (Range found in fastColoredTextBox1.GetRanges(@"\b(class|struct)\s+(?<range>\w+)\b"))
                fastColoredTextBox1.Range.SetStyle(NombreClases, @"\b" + found.Text + @"\b");
        }

        private void btnCompileRun_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Bookmarks.Clear();
            errorList.Items.Clear();
            input = txtInput.Text;


            if(cbRunWS.Checked == true)
            {
                path_file = Directory.GetCurrentDirectory() + @"\Coding Studio\file.cpp";
                StreamWriter sw = File.CreateText(path_file);
                sw.WriteLine("//");
                sw.WriteLine("//");
                sw.WriteLine("//");
                sw.WriteLine("//");
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();

                (new Task(() =>
                {
                    working = true;

                    Compile();
                    if (!errors.Contains("error"))
                        Run();

                    working = false;
                })).Start();
            }
            else
            {
                if (Save())
                {
                    (new Task(() =>
                    {
                        working = true;

                        Compile();
                        if (!errors.Contains("error"))
                            Run();

                        working = false;
                    })).Start();
                }
            }



        }
        private void btnCompile_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Bookmarks.Clear();

            errorList.Items.Clear();

            if (cbRunWS.Checked == true)
            {
                btnCompileRun_Click(null, null);
                return;
            }


                if (Save())
            (new Task(() =>
            {

                working = true;

                Compile();
                working = false;
            })).Start();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Bookmarks.Clear();

            if (cbRunWS.Checked == true)
            {
                btnCompileRun_Click(null, null);
                return;
            }

            fastColoredTextBox1.Zoom = 100; 
            input = txtInput.Text;
            if (path_file != "")
            {
                (new Task(() =>
                {

                    FileInfo FI = new FileInfo(path_file.Substring(0, path_file.Length - 3) + "exe");

                    if (FI.Exists)
                        Run();
                    else
                    {
                        working = true;

                        Compile();
                        if (errors == "")
                            Run();

                        working = false;
                    }

                })).Start();
            }
            else if (SaveAs())
            {
                working = true;

                Compile();
                if (errors == "")
                    Run();

                working = false;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                var ans = MessageBox.Show("Would you like to save your code?", "Before create a new code...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                    Save();
            }
            diffi = "";
            category = "";
            link = "";
            solved = false;
            filename = "New Code";
            saved = false;
            cbSolved.Checked = false;
            path_file = "";
            fastColoredTextBox1.Text = Properties.Resources.sample_code;
            fastColoredTextBox1.Focus();
            fastColoredTextBox1.Selection = new Range(fastColoredTextBox1, new Place(4, 5), new Place(4, 5));
            colorBar = Color.FromArgb(0, 122, 204);
            labelText = "Ready";
            errorList.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (path_file != "")
                Save();
            else
                SaveAs();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (saved == false)
                    {
                        var ans = MessageBox.Show("Would you like to save your code?", "Before create a new code...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                            Save();
                    }

                    path_file = (string)treeView1.SelectedNode.Tag;

                    StreamReader sr = new StreamReader(path_file);
                    diffi = sr.ReadLine().Substring(14);
                    category = sr.ReadLine().Substring(8);
                    link = sr.ReadLine().Substring(8);

                    string f = sr.ReadLine().Substring(10);
                    saved = bool.Parse(f);
                    cbSolved.Checked = saved;
                    fastColoredTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    fastColoredTextBox1.ClearUndo();
                    
                    filename = treeView1.SelectedNode.Text;
                    this.Text = "Coding Studio (" + treeView1.SelectedNode.Text + ")";
                    saved = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    string path = (string)treeView1.SelectedNode.Tag;

                    FileInfo FI = new FileInfo(path);
                    var ans = MessageBox.Show("Would you like to delete this code?", "Wait a second...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        FI.Delete();
                        btnNew_Click(null,null);
                    }
                    LoadTree();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    string path = (string)treeView1.SelectedNode.Tag;

                    StreamReader sr = new StreamReader(path);
                    diffi = sr.ReadLine().Substring(14);
                    category = sr.ReadLine().Substring(8);
                    link = sr.ReadLine().Substring(8);
                    string text = sr.ReadToEnd();
                    sr.Close();

                    FileInfo FI = new FileInfo(path);
                    SaveFile sf = new SaveFile();
                    sf.Diff = diffi;
                    sf.Code = category;
                    sf.Link = link;
                    sf.LastPath = path;

                    sf.FileName = FI.Name.Substring(0, FI.Name.Length - 4);
                    sf.FilePath = FI.Directory.ToString();
                    var ans = sf.ShowDialog();
                    if (ans == DialogResult.OK)
                    {
                        FI.Delete();
                        string p = sf.FilePath;
                        StreamWriter sw = File.CreateText(p);
                        sw.WriteLine("//Difficulty: " + sf.Diff);
                        sw.WriteLine("//Tags: " + sf.Code);
                        sw.WriteLine("//Link: " + sf.Link);
                        sw.Write(text);
                        sw.Close();
                        path_file = p;

                        diffi = sf.Diff;
                        category = sf.Code;
                        link = sf.Link;
                        path = sf.LastPath;


                    }
                    LoadTree();
                } }
        }

        Color colorBar = Color.FromArgb(0, 122, 204);
        string labelText = "Ready";
        private void programState_Tick(object sender, EventArgs e)
        {
            linkLabel1.Visible = cbSolved.Visible = label7.Visible = label6.Visible = !(path_file == "" || path_file == (Directory.GetCurrentDirectory() + @"\Coding Studio\file.cpp"));
            
            btnUndo1.Enabled = btnUndo.Enabled = fastColoredTextBox1.UndoEnabled;
            btnRedo1.Enabled = btnRedo.Enabled = fastColoredTextBox1.RedoEnabled;
            
            pState.BackColor = colorBar;
            lblState.Text = labelText;
            linkLabel1.Text = link;
            this.Text = filename + ((saved == false) ? "*" : "") + " - Coding Studio";
            lblName.Text = filename + ((saved == false) ? "*" : "");
            label6.Text = category;
            label7.Text = diffi;
            this.UseWaitCursor = working;

            //fastColoredTextBox1.ExpandAllFoldingBlocks();
            //fastColoredTextBox1.CollapseAllFoldingBlocks();

            if (exist_errors)
            {
                LoadErrors();
                exist_errors = false;
            }

            if (displaydata)
            {
                lblTimeUsed.Text = times.ToString() + " ms";
                lblExitValue.Text = exitval.ToString();
                try { txtOutput.Text = output; }
                catch { txtOutput.Text = "The output is to long for this machine :("; }
                lblMemoryUsed.Text = memory.ToString() + " KB";
                displaydata = false;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            (new Settings()).ShowDialog();

            StreamReader sr = new StreamReader(path_info);
            compiler_directory = sr.ReadLine();
            compiler_file = sr.ReadLine();
            version = sr.ReadLine();
            sr.Close();
            LoadTree();
            if (path_file != "")
            {
                FileInfo FI = new FileInfo(path_file);
                if (!FI.Exists)
                {
                    path_file = "";
                    saved = false;
                }
            }

        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "C++ files (*.cpp)|*.cpp|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = filename.Trim() + ".cpp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;

                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("//Difficulty: " + diffi);
                    sw.WriteLine("//Tags: " + category);
                    sw.WriteLine("//Link: " + link);
                    sw.Write(fastColoredTextBox1.Text);
                    sw.Close();

                }
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.InsertLinePrefix(fastColoredTextBox1.CommentPrefix);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "C++ files (*.cpp)|*.cpp|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
                foreach (string path in ofd.FileNames)
                {
                    FileInfo FI = new FileInfo(path);
                    if (FI.Exists && FI.Name.Substring(FI.Name.Length - 4) == ".cpp")
                    {
                        SaveFile obj = new SaveFile();
                        obj.FileName = FI.Name.Substring(0, FI.Name.Length - 4);
                        if (obj.ShowDialog() == DialogResult.OK)
                        {
                            path_file = Directory.GetCurrentDirectory() + @"\Coding Studio\Codes\" + obj.FileName + ".cpp";
                            FI.CopyTo(path_file);
                            diffi = obj.Diff;
                            category = obj.Code;
                            Save();

                        }
                    }
                }
            LoadTree();
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.AddStyle(SameWordsStyle);
        }

        private void btnYouTube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCCPOBzJTlf1u-UMRGMyDXVQ");
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
            foreach (string path in FileNames)
            {
                FileInfo FI = new FileInfo(path);
                if (FI.Exists && FI.Name.Substring(FI.Name.Length - 4) == ".cpp")
                {
                    SaveFile obj = new SaveFile();
                    obj.FileName = FI.Name.Substring(0, FI.Name.Length - 4);
                    if (obj.ShowDialog() == DialogResult.OK)
                    {
                        path_file = obj.FilePath;
                        FI.CopyTo(path_file);
                        diffi = obj.Diff;
                        category = obj.Code;
                        StreamReader sr = new StreamReader(path_file);
                        string text = sr.ReadToEnd();
                        sr.Close();

                        StreamWriter sw = File.CreateText(path_file);
                        sw.WriteLine("//Difficulty: " + obj.Diff);
                        sw.WriteLine("//Tags: " + obj.Code);
                        sw.WriteLine("//Link: " + obj.Link);
                        sw.Write(text);
                        sw.Close();
                    }
                }
            }
            LoadTree();
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void fastColoredTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void fastColoredTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
            try
            {
                FileInfo FI = new FileInfo(FileNames[0]);
                if (FI.Exists && FI.Name.Substring(FI.Name.Length - 4) == ".cpp")
                {
                    StreamReader sr = new StreamReader(FileNames[0]);
                    string text = sr.ReadToEnd();
                    sr.Close();
                    fastColoredTextBox1.Text = text;
                }
            }
            catch { }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Focus();
            fastColoredTextBox1.Selection = new Range(fastColoredTextBox1, new Place(4, 5), new Place(4, 5));
            //toolStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
            //toolStrip2.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            WebBrowser webBrowserForPrinting = new WebBrowser();
            webBrowserForPrinting.DocumentCompleted += (senders, es) => { ((WebBrowser)senders).ShowPrintPreviewDialog(); };
            webBrowserForPrinting.DocumentText = fastColoredTextBox1.Html;
        }

        private void fastColoredTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                btnCompileRun_Click(null, null);
            if (e.KeyCode == Keys.F4)
                btnCompile_Click(null, null);
            if (e.KeyCode == Keys.F6)
                btnRun_Click(null, null);
            if (e.KeyCode == Keys.S && e.Control)
                btnSave_Click(null, null);
        }

        private void btnPasteInput_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Text = Clipboard.GetText();
            }
            catch { }
        }

        private void btnCopyOutput_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtOutput.Text);
            }
            catch { }
        }

        private void btnUnncomment_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.RemoveLinePrefix(fastColoredTextBox1.CommentPrefix);

        }

        private void fastColoredTextBox1_SelectionChangedDelayed(object sender, EventArgs e)
        {
            fastColoredTextBox1.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fastColoredTextBox1.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fastColoredTextBox1.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fastColoredTextBox1.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }

        private void btnCloseCodes_Click(object sender, EventArgs e)
        {
            if (pCodes.Width == 13)
            {
                label8.Visible = true;
                pCodes.Width = 235;
                btnCloseCodes.Image = Properties.Resources.left;
            }
            else
            {
                label8.Visible = false;
                pCodes.Width = 13;
                btnCloseCodes.Image = Properties.Resources.right;
            }
        }

        private void btnCloseRuntimeData_Click(object sender, EventArgs e)
        {
            if (pRuntime.Width == 13)
            {
                btnCloseRuntimeData.Image = Properties.Resources.right;
                pRuntime.Width = 207;
            }
            else
            {
                btnCloseRuntimeData.Image = Properties.Resources.left;
                pRuntime.Width = 13;
            }
        }

        private void btnErrors_Click(object sender, EventArgs e)
        {
            if (pErrors.Height == 13)
            {
                btnErrors.Image = Properties.Resources.down;
                pErrors.Height = 126;
            }
            else
            {
                btnErrors.Image = Properties.Resources.up;
                pErrors.Height = 13;
            }

        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            if (this.Width < 857)
            {
                label8.Visible = false;
                pCodes.Width = 13;
                btnCloseCodes.Image = Properties.Resources.right;
            }
            if (this.Width < 626)
            {
                btnCloseRuntimeData.Image = Properties.Resources.left;
                pRuntime.Width = 13;
            }
            if (this.Height < 401)
            {
                btnErrors.Image = Properties.Resources.up;
                pErrors.Height = 13;
            }
        }

        private void btnOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            btnOpen_Click(null, null);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void documentMap1_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch { }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void virtualSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.VirtualSpace = !fastColoredTextBox1.VirtualSpace;
        }

        private void cbRunWS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSolved_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == false)
            {
                var ans = MessageBox.Show("Would you like to save your code?", "Before closing the program...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                    Save();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Help()).ShowDialog();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void btnDirectories_Click(object sender, EventArgs e)
        {
            (new EditDirectory()).ShowDialog();
            LoadTree();
        }
    }
}
