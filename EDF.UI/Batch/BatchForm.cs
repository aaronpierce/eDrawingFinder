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
            BatchUI.BatchConfirmButtonReference = BatchConfirmButton;
            BatchUI.BatchPrintButtonReference = BatchPrintButton;
            BatchUI.BatchDataGridReference = BatchDataGridView;
            BatchUI.ProgressBarReference = BatchPrintStatusProgressBar;
            BatchUI.StatusStripReference = StatusStrip;
            BatchUI.BatchFileTextBoxReference = BatchFileTextBox;

            BatchUI.BatchPrintStausLabelPreference = BatchPrintStatusLabel;
            BatchUI.BatchPrintStausLabelPreference.Text = "Ready";

            BatchUI.SendToBatchDataGridContextMenuStripRefernce.Enabled = true;


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
            BatchUI.SendToBatchDataGridContextMenuStripRefernce.Enabled = false;
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
