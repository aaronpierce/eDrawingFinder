using EDF.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            StatusBar.UpdateBatch("Ready");

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
            if (BatchFileLoad.Get())
                BatchDataGrid.SetInputIntoGrid();
        }

        private void BatchConfirmButton_Click(object sender, EventArgs e)
        {
            BatchDataGrid.Confirm();
        }

        private void BatchPrintButton_Click(object sender, EventArgs e)
        {
            BatchDataGrid.Print();
        }

        private void SearchBatchPrintContextMenuStrip_Click(object sender, EventArgs e)
        {
            Log.Write.Debug($"Search.Ready = {Search.Ready}");
            if (Search.Ready)
            {
                string keyword = BatchDataGrid.GetSelectedRowMatch().Part;
                Log.Write.Debug($"Keyword is {keyword}");
                MainReference.DataGridReference.DataSource = Search.Filter(MainReference.StartsWithCheckBoxReference.Checked, keyword, MainReference.OPCheckBoxReference.Checked, MainReference.BMCheckBoxReference.Checked);
                Program.MainFormReference.BringToFront();
            }
        }

        private void BatchDataGridView_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            bool status = true;
            if (BatchDataGrid.GetSelectedRowMatch().Drawing.File.Contains("Error"))
                status = false;

            DisabledContextDrawingOptions(status);

        }

        private void DisabledContextDrawingOptions(bool status)
        {
            SearchBatchPrintContextMenuStrip.Enabled = status;
            DrawingFilenameBatchDataGridContextMenuStrip.Enabled = status;
            FilePathBatchDataGridContextMenuStrip.Enabled = status;
            OpenWithDataGridContextMenuStrip.Enabled = status;
            RemoveDrawingDataContextMenuStrip.Enabled = status;
        }

        private void PartNumberBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextClipboard.BatchCopyPartNumber();
        }

        private void DrawingFilenameDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextClipboard.BatchCopyDrawingFileName();
        }

        private void FilePathBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextClipboard.BatchCopyFilePath();
        }

        private void EDrawingsBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextClipboard.BatchOpenWithEDrawings();
        }

        private void FileExplorerBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextClipboard.BatchOpenWithFileExplorer();
        }

        private void RemoveDrawingDataContextMenuStrip_Click(object sender, EventArgs e)
        {
            BatchDataGrid.ClearSelectedDrawing();
        }

        private void BatchDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            StatusBar.UpdateBatch($"Selected Part: {BatchDataGrid.GetSelectedRowMatch().Part}");
        }
    }
}
