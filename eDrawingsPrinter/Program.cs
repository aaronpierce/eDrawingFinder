using System;
using System.Windows.Forms;

namespace eDrawingFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        // Creates a reference to main form for resizing access.
        public static Form MainFormReference;
        [STAThread]
        static void Main()
        {
            if (!DotNetVersion.Get())
            {
                if (MessageBox.Show("Please Install Required .Net Version: 4.6.1\n\n Press Yes to begin installation.", ".Net Version Requirment", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"\\pokydata1\CAD\eDrawingFinder\eDrawingFinderDeploy\DotNet4.6.1.exe");
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainFormReference = new MainForm();
                Application.Run(MainFormReference);
            }
        }
    }
}
