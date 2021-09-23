using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingStudio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Starter());

            FileInfo DI = new FileInfo(Directory.GetCurrentDirectory() + @"\Coding Studio\info.ini");
            if (!DI.Exists)
            {
              if ( (new Creator()).ShowDialog() == DialogResult.OK)
                    Application.Run(new Principal());
            }
            else
                Application.Run(new Principal());

            
            }
    }
}
