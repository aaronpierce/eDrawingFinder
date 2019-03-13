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


            Search.StartsWithCheckBoxReference = StartsWithFilterCheckBox;
            Search.FilterTextBoxReference = FilterTextBox;
            DataGrid.DataGridReference = MainDataGridView;
            Data.PreCheckDataGridLoad();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
        }

        // Takes the selected items on the DataGridView and sends them through to a printer.
        private void PrintButton_Click(object sender, EventArgs e)
        {
            // If printing is in process, skip the printing processes from spawning again.
            if (!Printer.IsPrinting)
            {
                if (!(DataGrid.DataGridReference.AreAllCellsSelected(true)))
                {
                    Printer.IsPrinting = true;
                    Printer.Process(DrawingStorage.GetSelectedDrawings(MainDataGridView));
                }
                else
                {
                    MessageBox.Show("You cannot print ALL files.", "Error: All Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (!(DataGrid.DataGridReference.AreAllCellsSelected(true)))
            {
                IEnumerator<string> list = DrawingStorage.GetSelectedDrawings(DataGrid.DataGridReference);
                while (list.MoveNext())
                {
                    Process.Start(list.Current.ToString());
                    Log.Write.Info($"File opened: {list.Current.ToString()}");
                }
            }
            else
            {
                MessageBox.Show("You cannot open ALL files.", "Error: All Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
