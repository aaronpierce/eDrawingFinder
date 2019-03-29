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
            MatchList = PartToDrawing.Match(LoadedDrawingList);
            BatchReference.BatchDataGridReference.DataSource = MatchList;
            ProgressBarTearDown();

        }

        public static void PullMainSelectionToBatchCell()
        {
            IEnumerator<IDrawing> selectedMain = DataGrid.GetSelectedDrawings(MainReference.DataGridReference);
            if (selectedMain.MoveNext())
            {
                DataGridViewRow row = BatchReference.BatchDataGridReference.CurrentRow;
                MatchList[row.Index] = PartToDrawing.Match(new List<string>() { selectedMain.Current.File })[0];
                BatchReference.BatchDataGridReference.UpdateCellValue(1, row.Index);
            }

            DataGridStatistics();
        }

        public static void ClearSelectedDrawing()
        {
            DataGridViewRow row = BatchReference.BatchDataGridReference.CurrentRow;
            Matcher temp = PartToDrawing.Match(new List<string>() { row.Cells["Part"].Value.ToString() })[0];
            temp.Drawing.File = "Error; Manually Removed";
            MatchList[row.Index] = temp;
            BatchReference.BatchDataGridReference.UpdateCellValue(1, row.Index);

            DataGridStatistics();
        }

        public static Matcher GetSelectedRowMatch()
        {
            DataGridViewRow row = BatchReference.BatchDataGridReference.CurrentRow;
            return PartToDrawing.Match(new List<string>() { MatchList[row.Index].Part })[0];
        }

        private static void ProgressBarSetup()
        {
            StatusBar.UpdateBatch("Processing Imports...");
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

            FilePrint.Process(GetDrawings(), BatchReference.BatchDataGridReference.RowCount);

            StatusBar.UpdateBatch("Print Complete.");
            BatchReference.BatchConfirmButtonReference.Enabled = true;
        }

        public static IEnumerator<IDrawing> GetDrawings()
        {
            List<IDrawing> drawingsToPrint = new List<IDrawing>();

            foreach (Matcher match in MatchList)
            {
                if (File.Exists(match.Drawing.Path))
                    drawingsToPrint.Add(match.Drawing);
            }

            return ListToEnum.Convert(drawingsToPrint);
        }

        public static void DataGridStatistics()
        {
            StatusBar.UpdateBatch($"Errors Found: {ErrorCount().ToString()}");
            BatchReference.StatusStripReference.Update();
        }

        private static int ErrorCount()
        {
            int counter = 0;
            foreach (DataGridViewRow row in BatchReference.BatchDataGridReference.Rows)
            {
                if (row.Cells["Drawing"].Value.ToString().Contains("Error")) { counter++; }
            }
            return counter;
        }

        public static void Confirm()
        {
            string printer = FilePrint.SelectedPrinter ?? FilePrint.PrinterSettings.PrinterName;
            printer = printer.Contains(@"\") ? printer.Split('\\').Last() : printer;

            string text = $"There are {ErrorCount()} non-matched part numbers.\n" +
                ((ErrorCount() == 0) ? "\n" : "These are to be skipped and will NOT print.\n\n") +
                $"{BatchReference.BatchDataGridReference.RowCount - ErrorCount()} drawings will be staged for printing.\n\n" +
                "The following printer is currently selected:\n" +
                $"{printer} \n\n" +
                "Would you like to confirm this and continue?";
            string caption = "Confirmation";
            DialogResult conf = MessageBox.Show(text: text, caption: caption, buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Question);
            if (conf.ToString() == "OK")
            {
                BatchReference.BatchConfirmButtonReference.Enabled = false;
                BatchReference.BatchPrintButtonReference.Enabled = true;
                StatusBar.UpdateBatch($"Printing is ready. {BatchReference.BatchDataGridReference.RowCount-ErrorCount()} file(s) will be sent to {printer}.");
            }
            else
            {
                Log.Write.Info("Batch Print Job Cancelled.");
            }
                
        }

    }


}
