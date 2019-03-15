using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
{
    public partial class BatchForm : Form
    {
        public BatchForm()
        {
            InitializeComponent();
        }

        private static bool IsOpen {get; set;} = false;

        public static BatchForm New()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                return new BatchForm();
            }
            else
            {
                MainForm.batchForm.BringToFront();
                return MainForm.batchForm;
            }
        }

        private void BatchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            Data.BatchPrintLoadFile();
            BatchDataGrid.SetInputIntoGrid();
        }

        private void BatchForm_Load(object sender, EventArgs e)
        {
            BatchDataGrid.BatchDataGridReference = BatchDataGridView;
        }
    }
}
