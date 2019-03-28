using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    public partial class PrintProgressForm : Form
    {
        public static Thread PrintProgressFormThread { get; set; }
        public static ProgressBar PrintProgressBarReference { get; set; }
        public PrintProgressForm()
        {
            InitializeComponent();
            PrintProgressBarReference = PrintProgressBar;
        }

        public static PrintProgressForm Display()
        {
            PrintProgressForm printProgressForm = new PrintProgressForm();

            Thread PrintProgressFormThread = new Thread(() => printProgressForm.ShowDialog());
            PrintProgressFormThread.Start();

            return printProgressForm;
        }

        public void ProgressBarSetup(int totalCount)
        {
            PrintProgressBar.Visible = true;
            PrintProgressBar.Value = 0;
            PrintProgressBar.Step = (totalCount / 100);
        }

        public void ProgressBarTeardown()
        {
            PrintProgressBar.Visible = false;
        }


        public void ShowProgress()
        {
            PrintProgressBar.Increment(PrintProgressBar.Step);
        }
    }
}
