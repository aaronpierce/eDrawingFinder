﻿using System;
using System.Windows.Forms;
using EDF.Common;
using Squirrel;
using EDF.BL;
using System.Threading;
using EDF.DL;

namespace EDF.UI
{
    public partial class MainForm : Form
    {
        // Gives the form access to the eDrawingHostControl as eDrawings.Control
        public static EDrawings eDrawings = new EDrawings();
        public static BatchForm batchForm;
        public static TestForm testForm;
    
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.Write.Info("################## - New application instance has started - ##################");
            SetDrawingControls();
            SetUIReferences();

            DatabasePreCheck();
            DataGrid.MainLoad();

            Preview.Expand();

            UserSettings.Apply();
            FilePrint.SetPrinterOptions();

            CheckForUpdate();

            Log.Write.Info("Passed loading phase in Main Form");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettings.Save();
        }

        private void SetDrawingControls()
        {
            // If eDrawings >= 2018 is not installed these will be null and application will close.
            if (eDrawings.Control is null || eDrawings.PreviewControl is null) { this.Close(); }

            // Once the form loads, add the Control and set it to invisible.
            this.Controls.Add(eDrawings.Control);
            eDrawings.Control.Visible = false;

            this.PreviewPanel.Controls.Add(eDrawings.PreviewControl);
        }

        private void DatabasePreCheck()
        {
            if (!DirectoryScan.DatabaseExists())
            {
                Log.Write.Info("Database needed to be built/rebuilt.");
                AlertForm.ShowCreateDBAlert();
                DirectoryScan.PreLoadDatabase();
                AlertForm.CreateDBAlertThread.Abort();
            }
        }

        private async void CheckForUpdate()
        {
            using (var updateManager = new UpdateManager(@"\\pokydata1\CAD\eDrawingFinder\Releases"))
            {
                VersionMainStatusStrip.Text = $"eDrawing Finder, Version {updateManager.CurrentlyInstalledVersion()}";
                VersionMainStatusStrip.Alignment = ToolStripItemAlignment.Right;
                var releaseEntry = await updateManager.UpdateApp();
                Log.Write.Info($"Current application version [{updateManager.CurrentlyInstalledVersion()}] | {$"Version [{releaseEntry?.Version.ToString()}] update is pending application restart" ?? "No updates found"}");
            }
        }

        private void RefreshFilterResults(string keyword = ".")
        {
            MainDataGridView.ClearSelection();
            if (Search.Ready)
                keyword = (keyword == ".") ? FilterTextBox.Text : keyword;
                MainDataGridView.DataSource = Search.Filter(StartsWithFilterCheckBox.Checked, keyword, OPCheckBox.Checked, BMCheckBox.Checked);

        }

        // Takes the selected items on the DataGridView and sends them through to a printer.
        private void PrintButton_Click(object sender, EventArgs e)
        {
            FilePrint.PreProcess();
        }

        // Opens selected files in data grid when clicking button
        private void OpenButton_Click(object sender, EventArgs e)
        {
            FileOpen.PreProcess();   
        }

        // Apply search filter instantly when box is checked.
        private void StartsWithFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshFilterResults();
        }



        private void PrinterSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() => FilePrint.SelectedPrinter = PrinterSelectionComboBox.Text));
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
            RefreshFilterResults();
        }

        private void MainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (Preview.MainFormExpanded && (DataGrid.SelectionLessThanOrEqual(1, MainDataGridView)))
                Preview.ShowDrawing();

            if (DataGrid.SelectionLessThanOrEqual(1, MainDataGridView)) { 
                StatusBar.UpdateMain($"Selected: {DataGrid.GetFirstSelectedDrawing(MainDataGridView).File}");
            }
            else
            {
                StatusBar.UpdateMain($"{DataGrid.CountOfSelection(MainDataGridView)} drawings selected.");
            }
        }

        private void PartNumberDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000, MainDataGridView))
                ContextClipboard.CopyPartNumber(MainDataGridView);
        }

        private void DrawingFilenameDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000, MainDataGridView))
                ContextClipboard.CopyDrawingFileName(MainDataGridView);
        }

        private void FilePathDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1000, MainDataGridView))
                ContextClipboard.CopyFilePath(MainDataGridView);
        }

        private void FileExplorerDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(5, MainDataGridView))
                ContextClipboard.OpenWithFileExplorer(MainDataGridView);
        }

        private void SendToBatchDataGridContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectionLessThanOrEqual(1, MainDataGridView))
                BatchDataGrid.PullMainSelectionToBatchCell();

        }

        private void BMCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!BMCheckBox.Checked && !OPCheckBox.Checked)
            {
                OPCheckBox.Checked = true;
            }
            else
            {
                RefreshFilterResults();
            }
        }

        private void OPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!OPCheckBox.Checked && !BMCheckBox.Checked)
            {
                BMCheckBox.Checked = true;
            }
            else
            {
                RefreshFilterResults();
            }
        }

        private void UpdateDBMainToolStripMenu_Click(object sender, EventArgs e)
        {
            if (DirectoryScan.PostLoadComplete)
            {
                DirectoryScan.ManualLoadUpdateTask.Start();
                StatusBar.UpdateMain("Scanning drives for drawings.");
                Log.Write.Info("Manually start postload db update");
            }
            else
            {
                StatusBar.UpdateMain("Update already in progress.");
            }
        }

        private void SetUIReferences()
        {
            MainReference.SendToBatchDataGridContextMenuStripReference = SendToBatchDataGridContextMenuStrip;
            MainReference.PreviewNameTextBoxRefernce = PreviewNameTextBox;
            MainReference.PreviewLastModifiedTextBoxReference = PreviewLastModifiedTextBox;
            MainReference.PreviewRevisionTextBoxReference = PreviewRevisionTextBox;
            MainReference.PrinterSelectionComboBoxReference = PrinterSelectionComboBox;
            MainReference.StartsWithCheckBoxReference = StartsWithFilterCheckBox;
            MainReference.FilterTextBoxReference = FilterTextBox;
            MainReference.DataGridReference = MainDataGridView;
            MainReference.StatusStripStatusLabelReference = StatusStripStatusLabel;
            MainReference.OPCheckBoxReference = OPCheckBox;
            MainReference.BMCheckBoxReference = BMCheckBox;
            MainReference.EDrawingsDefaultMainToolStipMenuReference = EDrawingsDefaultMainToolStipMenu;

            BatchReference.SendToBatchDataGridContextMenuStripRefernce = SendToBatchDataGridContextMenuStrip;

        }

        private void EDrawingsDefaultMainToolStipMenu_Click(object sender, EventArgs e)
        {
            Log.Write.Debug($"CheckBox Status [{EDrawingsDefaultMainToolStipMenu.Checked}]");

            if (string.IsNullOrEmpty(FileOpen.EDrawingsInstall))
                FileOpen.EDrawingsInstall = Data.GetEDrawingsExecutable();

            Log.Write.Info($"eDrawing open with set to {(EDrawingsDefaultMainToolStipMenu.Checked ? (!string.IsNullOrEmpty(FileOpen.EDrawingsInstall) ? FileOpen.EDrawingsInstall : "OS defined.") : "OS defined.")}");
        }
        
    }
}
