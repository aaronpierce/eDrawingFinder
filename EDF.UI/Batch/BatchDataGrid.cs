using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDF.DL;
using EDF.Common;
using EDF.UI;

namespace EDF.UI
{
    public class BatchDataGrid
    {
        public static DataTable BatchDataTable { get; set; }
        public static List<string> LoadedDrawingList { get; set; }
        public static List<Matcher> MatchList { get; set; }

        public static void SetInputIntoGrid()
        {
            ProgressBarSetup();
            MatchList = DrawingToPart.Match(LoadedDrawingList);
            BatchReference.BatchDataGridReference.DataSource = MatchList;
            ProgressBarTearDown();

        }

        public static void PullMainSelectionToBatchCell()
        {
            IEnumerator<string> selectedMain = DataGrid.GetSelectedDrawings();
            if (selectedMain.MoveNext())
            {
                DataGridViewRow row = BatchReference.BatchDataGridReference.CurrentRow;
                MatchList[row.Index] = DrawingToPart.Match(new List<string>() { Path.GetFileName(selectedMain.Current) })[0];
                BatchReference.BatchDataGridReference.UpdateCellValue(1, row.Index);
            }    
        }

        private static void ProgressBarSetup()
        {
            BatchReference.BatchPrintStausLabelPreference.Text = "Processing Imports...";
            BatchReference.StatusStripReference.Update();
            BatchReference.ProgressBarReference.Visible = true;
            BatchReference.ProgressBarReference.Step = LoadedDrawingList.Count / 100;
            BatchReference.ProgressBarReference.Value = 0;
        }

        private static void ProgressBarTearDown()
        {
            BatchReference.ProgressBarReference.Visible = false;
            DataGridStatistics();
            BatchReference.BatchConfirmButtonReference.Enabled = true;
        }

        public static void Print()
        {
            Log.Write.Info("Batch Print Job Started.");

            BatchReference.BatchPrintButtonReference.Enabled = false;

            FilePrint.Process(GetDrawingPaths());

            BatchReference.BatchConfirmButtonReference.Enabled = true;
        }

        public static IEnumerator<string> GetDrawingPaths()
        {
            List<string> drawingsToPrint = new List<string>();

            foreach (Matcher match in MatchList)
            {
                if (File.Exists(match.Drawing.Path))
                    drawingsToPrint.Add(match.Drawing.Path);
            }

            return ListToEnum.Convert(drawingsToPrint);
        }

        public static void DataGridStatistics()
        {
            BatchReference.BatchPrintStausLabelPreference.Text = $"Errors Found: {ErrorCount().ToString()}";
            BatchReference.StatusStripReference.Update();
        }

        private static int ErrorCount()
        {
            return 0;
        }

        public static void Confirm()
        {

            string text = $"There are {ErrorCount()} non-associated part numbers.\nThese are to be skipped and will NOT print.\n\nThe following printer is currently selected:\n{FilePrint.SelectedPrinter ?? FilePrint.PrinterSettings.PrinterName} \n\nWould you like to confirm this and continue?";
            string caption = "Confimation";
            DialogResult conf = MessageBox.Show(text: text, caption: caption, buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Question);
            if (conf.ToString() == "OK")
            {
                BatchReference.BatchConfirmButtonReference.Enabled = false;
                BatchReference.BatchPrintButtonReference.Enabled = true;
            }
            else
            {
                Log.Write.Info("Batch Print Job Cancelled.");
            }
                
        }

    }


}
