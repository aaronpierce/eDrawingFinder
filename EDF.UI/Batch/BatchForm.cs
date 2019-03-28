using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{

    public partial class BatchForm : Form
    {
        private static bool IsOpen { get; set; } = false;
        

        public BatchForm()
        {
            InitializeComponent();
        }

        private void BatchForm_Load(object sender, EventArgs e)
        {
            BatchReference.BatchConfirmButtonReference = BatchConfirmButton;
            BatchReference.BatchPrintButtonReference = BatchPrintButton;

            BatchReference.BatchDataGridReference = BatchDataGridView;
            BatchReference.ProgressBarReference = BatchPrintStatusProgressBar;
            BatchReference.StatusStripReference = StatusStrip;

            BatchReference.BatchFileTextBoxReference = BatchFileTextBox;

            BatchReference.BatchOPCheckBoxReference = BatchOPCheckBox;
            BatchReference.BatchBMCheckBoxReference = BatchBMCheckBox;

            BatchReference.BatchPrintStausLabelPreference = BatchPrintStatusLabel;
            BatchReference.BatchPrintStausLabelPreference.Text = "Ready";

            BatchReference.SendToBatchDataGridContextMenuStripRefernce.Enabled = true;


        }

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
            BatchReference.SendToBatchDataGridContextMenuStripRefernce.Enabled = false;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            BatchFileLoad.Get();
            BatchDataGrid.SetInputIntoGrid();
        }

        private void BatchDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            BatchDataGrid.DataGridStatistics();
        }

        private void BatchConfirmButton_Click(object sender, EventArgs e)
        {
            BatchDataGrid.Confirm();
        }

        private void BatchPrintButton_Click(object sender, EventArgs e)
        {
            BatchDataGrid.Print();
        }
    }
}
