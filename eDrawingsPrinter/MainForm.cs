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
        }

        // Takes the selected items on the DataGridView and sends them through to a printer.
        private void ButtonTestPrint_Click(object sender, EventArgs e)
        {

            // If printing is in process, skip the printing processes from spawning again.
            if (!eDrawings.IsPrinting)
            {
                eDrawings.IsPrinting = true;
                List<string> items = new List<string>();
                foreach (DataGridViewTextBoxCell item in dataGridView1.SelectedCells)
                {
                    if (item.ColumnIndex == 1)
                    {
                        items.Add(item.Value.ToString());
                        Console.WriteLine(item.Value.ToString());
                    }
                }

                // Gets an enumearator from selected data grid items and sends those into the printer functions
                IEnumerator<string> DrawingList = DrawingStorage.DataGridDrawings(items);
                Printer.Process(DrawingList);
            }
        }

        // Calls directory scanning functions on button click.
        private void FileTreeButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            // Takes input of textbox as argument on which directory to scan
            FileTree.GetDWGFiles(FilePathTextbox.Text);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            // Calls function for seeing directory size, and saving directory to json.
            FileTree.CheckDictionary();
        }

        // Takes json file and fills data grid view with that data
        private void LoadDataSourceButton_Click(object sender, EventArgs e)
        {
            // Calling this loads json data to disk, converts from dictionary to data table and updates DrawingDataTable.
            DrawingStorage.SetDataTable();

            // Uses the just updated variable DrawingDataTable as the data source for grid view.
            dataGridView1.DataSource = DrawingStorage.DrawingDataTable;
        }

        // Filters datagrid on filename but given textbox value on button click.
        private void FilterButton_Click(object sender, EventArgs e)
        {
            // If contains check box is checked, add '%' in front of the filtering text as a wildcard.
            var Contains = ContainsFilterCheckBox.Checked == false ? "" : "%";

            // Takes first column name and applies to a filter string
            var Filter = $"{dataGridView1.Columns[0].HeaderText.ToString()} LIKE '{Contains}{FilterTextBox.Text}%'";

            DrawingStorage.DrawingDataTable.DefaultView.RowFilter = Filter;
            

        }
    }
}
