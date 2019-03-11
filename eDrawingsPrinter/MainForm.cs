using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingsPrinter
{
    public partial class MainForm : Form
    {
        public static EDrawings eDrawings = new EDrawings();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(eDrawings.Control);
            eDrawings.Control.Visible = false;
        }
        private void ButtonTestPrint_Click(object sender, EventArgs e)
        {
            if (!eDrawings.IsPrinting)
            {
                eDrawings.IsPrinting = true;
                Printer.Process(DrawingStorage.DrawingList);
            }
        }

        private void FileTreeButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            FileTree.Test(FilePathTextbox.Text);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            FileTree.CheckDictionary();
        }
    }
}
