using System;
using System.Windows.Forms;
using EDF.UI;

namespace EDF.UI
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainFormReference = new MainForm();
            Application.Run(MainFormReference);
        }
    }
}
