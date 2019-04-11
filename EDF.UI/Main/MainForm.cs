using System;
using System.Windows.Forms;
using EDF.Common;
using Squirrel;
using EDF.BL;
using System.Threading;
using EDF.DL;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace EDF.UI
{
    public partial class MainForm : Form
    {
        // Gives the form access to the eDrawingHostControl as eDrawings.Control
        public static EDrawings eDrawings = new EDrawings();
        public static BatchForm batchForm;
        public static TestForm testForm;

        // Use these variables for test/prod release builds to prevent local installation on every VS build.       
        public static bool ReleasingProd = false;
        public static bool ReleasingTest = false;
        public static string UpdateLocation = (ReleasingProd) ? @"\\pokydata1\CAD\eDrawingFinder\Releases" : (ReleasingTest) ? @"\\pokydata1\CAD\eDrawingFinder\Releases" : @"";
        
    
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ReleasingProd || ReleasingTest) { CheckForUpdate(); }
            Log.Write.Info("################## - Application instance has started - ##################");

            if (SetDrawingControls())
            {               
                SetDrawingControls();
                SetUIReferences();

                DatabasePreCheck();
                DataGrid.MainLoad();

                Preview.Expand();

                UserSettings.Apply();
                FilePrint.SetPrinterOptions();

                Log.Write.Info("Passed loading phase in Main Form");
            }
            else
            {
                Environment.Exit(0);
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettings.Save();
            Log.Write.Info("################## - Application instance has closed - ##################");
        }

        private bool SetDrawingControls()
        {
            // If eDrawings >= 2018 is not installed these will be null and application will close.
            if (!(eDrawings.Control is null || eDrawings.PreviewControl is null))
            { 
                     // Once the form loads, add the Control and set it to invisible.
                this.Controls.Add(eDrawings.Control);
                eDrawings.Control.Visible = false;

                this.PreviewPanel.Controls.Add(eDrawings.PreviewControl);
                return true;
            }
            else
            {
                MessageBoxes.EDrawingsRequirmentError();
                return false;
            }
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
            using (var updateManager = new UpdateManager(UpdateLocation))
            {
                VersionMainStatusStrip.Text = $"eDrawing Finder, Version {updateManager.CurrentlyInstalledVersion()}";
                VersionMainStatusStrip.Alignment = ToolStripItemAlignment.Right;
                ReleaseEntry releaseEntry = await updateManager.UpdateApp();
                Log.Write.Info($"Current application version [{updateManager.CurrentlyInstalledVersion()}] | {((string.IsNullOrEmpty(releaseEntry?.Version.ToString())) ? "No updates found" : $"Version [{releaseEntry?.Version.ToString()}] update is pending application restart")}");                                                
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

        private void OPBMCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (!OPCheckBox.Checked && !BMCheckBox.Checked)
            {
                OPCheckBox.CheckedChanged -= OPBMCheckBox_CheckedChanged;
                BMCheckBox.CheckedChanged -= OPBMCheckBox_CheckedChanged;

                //Set both to checked to ensure one stays checked
                OPCheckBox.Checked = true;
                BMCheckBox.Checked = true;

                //Uncheck the one that was intended to be unchecked
                checkBox.Checked = false;

                OPCheckBox.CheckedChanged += OPBMCheckBox_CheckedChanged;
                BMCheckBox.CheckedChanged += OPBMCheckBox_CheckedChanged;
            }

            if (CheckboxFilterMainToolStipMenu.Checked)
            {
                RefreshFilterResults();
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
            MainReference.CheckboxFilterMainToolStipMenuReference = CheckboxFilterMainToolStipMenu;

            BatchReference.SendToBatchDataGridContextMenuStripRefernce = SendToBatchDataGridContextMenuStrip;

        }

        private void EDrawingsDefaultMainToolStipMenu_Click(object sender, EventArgs e)
        {
            Log.Write.Debug($"CheckBox Status [{EDrawingsDefaultMainToolStipMenu.Checked}]");

            if (string.IsNullOrEmpty(FileOpen.EDrawingsInstall))
                FileOpen.EDrawingsInstall = Data.GetMostRecentEDrawingInstall();

            Log.Write.Info($"eDrawing open with set to {(EDrawingsDefaultMainToolStipMenu.Checked ? (!string.IsNullOrEmpty(FileOpen.EDrawingsInstall) ? FileOpen.EDrawingsInstall : "OS defined.") : "OS defined.")}");
        }

        private void UpdateDBMainToolStripMenu_Click_1(object sender, EventArgs e)
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

        private void UpdateAppMainToolStripMenu_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
            StatusBar.UpdateMain("Checking for application update.");
        }

        private void LogsMainToolStripMenu_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Data.ProgramFolder, "logs"));
            StatusBar.UpdateMain("Log file folder opened.");
        }
    }
}
