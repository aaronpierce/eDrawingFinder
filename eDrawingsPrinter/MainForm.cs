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
using System.Drawing.Printing;

namespace eDrawingFinder
{
    public partial class MainForm : Form
    {
        // Gives the form access to the eDrawingHostControl as eDrawings.Control
        public static EDrawings eDrawings = new EDrawings();
        public static BatchForm batchForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Once the form loads, add the Control and set it to invisible.
            this.Controls.Add(eDrawings.Control);
            eDrawings.Control.Visible = false;

            this.PreviewPanel.Controls.Add(eDrawings.PreviewControl);

            //eDrawings.PreviewControl.eDrawingControlWrapper.

            Preview.PreviewNameTextBoxRefernce = PreviewNameTextBox;
            Preview.PreviewLastModifiedTextBoxReference = PreviewLastModifiedTextBox;
            Preview.PreviewRevisionTextBoxReference = PreviewRevisionTextBox;
            Printer.PrinterSelectionComboBoxRefrence = PrinterSelectionComboBox;
            Search.StartsWithCheckBoxReference = StartsWithFilterCheckBox;
            Search.FilterTextBoxReference = FilterTextBox;
            DataGrid.DataGridReference = MainDataGridView;
            Data.PreCheckDataGridLoad();

            Preview.Expand();


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
                if ((DataGrid.DataGridReference.AreAllCellsSelected(true)) && (DataGrid.DataGridReference.SelectedRows.Count > 10))
                {
                    MessageBox.Show("Too many files are currently selected.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Printer.IsPrinting = true;
                    Printer.Process(DrawingStorage.GetSelectedDrawings(MainDataGridView));
                }
            }
        }

        // Opens selected files in data grid when clicking button
        private void OpenButton_Click(object sender, EventArgs e)
        {

            if ((DataGrid.DataGridReference.AreAllCellsSelected(true)) && (DataGrid.DataGridReference.SelectedRows.Count > 10))
            {
                MessageBox.Show("Too many files are currently selected.", "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IEnumerator<string> list = DrawingStorage.GetSelectedDrawings(DataGrid.DataGridReference);
                while (list.MoveNext())
                {
                    Process.Start(list.Current.ToString());
                    Log.Write.Info($"File opened: {list.Current.ToString()}");
                }
            }
                
        }

        // Apply search filter instantly when box is checked.
        private void StartsWithFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void OPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DrawingStorage.CurrentDataTable = DrawingStorage.OPDrawingDataTable;
            DataGrid.DataGridReference.DataSource = DrawingStorage.CurrentDataTable;
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void BMRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DrawingStorage.CurrentDataTable = DrawingStorage.BMDrawingDataTable;
            DataGrid.DataGridReference.DataSource = DrawingStorage.CurrentDataTable;
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void SettingsMainToolStripMenu_Click(object sender, EventArgs e)
        {
            Printer.SetPrinterOptions();
        }

        private void PrinterSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() => Printer.SelectedPrinter = PrinterSelectionComboBox.Text));
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            Preview.Expand();
        }

        private void BatchPrintMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batchForm = BatchForm.New();
            batchForm.Show();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            MainDataGridView.ClearSelection();
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void MainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (Preview.MainFormExpanded && (MainDataGridView.SelectedRows.Count == 1))
                Preview.ShowDrawing();
        }
    }
}
