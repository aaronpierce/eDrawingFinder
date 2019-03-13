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

namespace eDrawingsPrinter
{
    public partial class MainForm : Form
    {
        // Gives the form access to the eDrawingHostControl as eDrawings.Control
        public static EDrawings eDrawings = new EDrawings();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Once the form loads, add the Control and set it to invisible.
            this.Controls.Add(eDrawings.Control);
            eDrawings.Control.Visible = false;

            DataGrid.DataGridReference = MainDataGridView;
            Data.PreCheckDataGridLoad();
        }

        // Takes the selected items on the DataGridView and sends them through to a printer.
        private void PrintButton_Click(object sender, EventArgs e)
        {

            // If printing is in process, skip the printing processes from spawning again.
            if (!eDrawings.IsPrinting)
            {
                eDrawings.IsPrinting = true;
               
                Printer.Process(DrawingStorage.GetSelectedDrawings(MainDataGridView));
            }
        }

        // Apply search filters to data grid view on search button click.
        private void FilterSearchButton_Click(object sender, EventArgs e)
        {
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        // Opens selected files in data grid when clicking button
        private void OpenButton_Click(object sender, EventArgs e)
        {
            IEnumerator<string> list = DrawingStorage.GetSelectedDrawings(DataGrid.DataGridReference);
            while (list.MoveNext())
            {
                Process.Start(list.Current.ToString());
                Log.Write.Info($"File opened: {list.Current.ToString()}");
            }
                
        }

        // Apply search filter instantly when box is checked.
        private void StartsWithFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void OPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DataGrid.DataGridReference.DataSource = DrawingStorage.OPDrawingDataTable;
        }

        private void BMRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DataGrid.DataGridReference.DataSource = DrawingStorage.BMDrawingDataTable;
        }
    }
}
