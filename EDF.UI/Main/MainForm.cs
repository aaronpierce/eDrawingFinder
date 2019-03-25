using System;
using System.Windows.Forms;
using EDF.Common;
using Squirrel;
using EDF.DL;


namespace EDF.UI
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
            if (eDrawings.Control is null || eDrawings.PreviewControl is null) { this.Close();  }
            // Once the form loads, add the Control and set it to invisible.
            this.Controls.Add(eDrawings.Control);
            eDrawings.Control.Visible = false;

            this.PreviewPanel.Controls.Add(eDrawings.PreviewControl);


            MainReference.SendToBatchDataGridContextMenuStripReference = SendToBatchDataGridContextMenuStrip;
            MainReference.PreviewNameTextBoxRefernce = PreviewNameTextBox;
            MainReference.PreviewLastModifiedTextBoxReference = PreviewLastModifiedTextBox;
            MainReference.PreviewRevisionTextBoxReference = PreviewRevisionTextBox;
            MainReference.PrinterSelectionComboBoxReference = PrinterSelectionComboBox;
            MainReference.StartsWithCheckBoxReference = StartsWithFilterCheckBox;
            MainReference.FilterTextBoxReference = FilterTextBox;
            MainReference.DataGridReference = MainDataGridView;

            BatchUI.SendToBatchDataGridContextMenuStripRefernce = SendToBatchDataGridContextMenuStrip;

            DirectoryScan.PreCheckDataGridLoad();
            DataGrid.Load();

            Preview.Expand();

            // Apply Settings
            if (!(Properties.Settings.Default.FormExpanded == Preview.MainFormExpanded))
                Preview.Expand();

            if (!(Properties.Settings.Default.DefaultPrinter == String.Empty))
                Printer.SelectedPrinter = Properties.Settings.Default.DefaultPrinter;

             CheckForUpdate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Set and Save Settings
            Properties.Settings.Default.DefaultPrinter = Printer.SelectedPrinter;
            Properties.Settings.Default.FormExpanded = Preview.MainFormExpanded;
            Properties.Settings.Default.Save();
        }

        private async void CheckForUpdate()
        {
            using (var updateManager = new UpdateManager(@"\\pokydata1\CAD\eDrawingFinder\Releases"))
            {
                VersionMainStatusStrip.Text = $"eDrawing Finder, Version {updateManager.CurrentlyInstalledVersion()}";
                VersionMainStatusStrip.Alignment = ToolStripItemAlignment.Right;
                var releaseEntry = await updateManager.UpdateApp();
                Log.Write.Info($"Current Version: {updateManager.CurrentlyInstalledVersion()} -- {$"{releaseEntry?.Version.ToString()} Version update found." ?? "No update found."}");
            }
        }

        // Takes the selected items on the DataGridView and sends them through to a printer.
        private void PrintButton_Click(object sender, EventArgs e)
        {
            Printer.PreProcess();
        }

        // Opens selected files in data grid when clicking button
        private void OpenButton_Click(object sender, EventArgs e)
        {
            Opener.PreProcess();   
        }

        // Apply search filter instantly when box is checked.
        private void StartsWithFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void OPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DrawingStorage.CurrentDataTable = DrawingStorage.OPDrawingDataTable;
            MainReference.DataGridReference.DataSource = DrawingStorage.CurrentDataTable;
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void BMRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DrawingStorage.CurrentDataTable = DrawingStorage.BMDrawingDataTable;
            MainReference.DataGridReference.DataSource = DrawingStorage.CurrentDataTable;
            Search.Filter(StartsWithFilterCheckBox.Checked, FilterTextBox.Text);
        }

        private void SettingsMainToolStripMenu_Click(object sender, EventArgs e)
        {
            Printer.SetPrinterOptions();
            MainReference.PrinterSelectionComboBoxReference.SelectedItem = Printer.SelectedPrinter;
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
            if (Preview.MainFormExpanded && (DataGrid.SelectionLessThanOrEqual(1)))
                Preview.ShowDrawing();
        }

        private void PartNumberDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000))
                ContextClipboard.CopyPartNumber();
        }

        private void DrawingFilenameDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000))
                ContextClipboard.CopyDrawingFileName();
        }

        private void FilePathDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000))
                ContextClipboard.CopyFilePath();
        }

        private void FileExplorerDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(5))
                ContextClipboard.OpenWithFileExplorer();
        }

        private void SendToBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1))
                BatchDataGrid.PullMainSelectionToBatchCell();

        }
    }
}
