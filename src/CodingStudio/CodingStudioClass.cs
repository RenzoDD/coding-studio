using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingStudio
{
    public class TestColorTable : ProfessionalColorTable
    {
        Color culoare = Color.FromArgb(30, 30, 30);
        Color culoare1 = Color.FromArgb(10, 10, 10);
        Color culoare2 = Color.FromArgb(60, 60, 60);
        
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(51, 51, 51); }
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(51, 51, 51); }
        }

        public override Color ButtonSelectedGradientBegin
        { get { return Color.FromArgb(60, 60, 60); } }
        public override Color ButtonSelectedGradientEnd
        { get { return Color.FromArgb(60, 60, 60); } }
        public override Color ButtonSelectedBorder
        { get { return Color.FromArgb(60, 60, 60); } }

        public override Color MenuItemPressedGradientBegin
        {
            get { return culoare2; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return culoare2; }
        }
        public override Color MenuBorder
        { get { return culoare; } }


        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(60, 60, 60); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(60, 60, 60); }
        }

        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(0, 122, 204);
            }
        }
        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(0, 122, 204);
            }
        }
        public override Color ToolStripBorder
        {
            get
            {  return Color.FromArgb(45, 45, 45);  }
        }

    }
    public class Problem
    {
        public int contestId { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double points { get; set; }
        public int rating { get; set; }
        public List<string> tags { get; set; }
    }

    public class ProblemStatistic
    {
        public int contestId { get; set; }
        public string index { get; set; }
        public int solvedCount { get; set; }
    }

    public class Result
    {
        public List<Problem> problems { get; set; }
        public List<ProblemStatistic> problemStatistics { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public Result result { get; set; }
    }
}