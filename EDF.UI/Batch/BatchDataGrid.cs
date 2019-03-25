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
        public static Dictionary<string, string> MatchedDrawings { get; set; }

        public static void SetInputIntoGrid()
        {
            ProgressBarSetup();
            MatchedDrawings = FindMatch();
            BatchDataTable = ConvertToDataTable(MatchedDrawings);
            BatchUI.BatchDataGridReference.DataSource = BatchDataTable;
            ProgressBarTearDown();

        }

        private static DataTable ConvertToDataTable(Dictionary<string, string> MatchedDrawings)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Part_Number");
            dt.Columns.Add("Drawing_File");

            foreach (KeyValuePair<string, string> item in MatchedDrawings)
            {
                DataRow row = dt.NewRow();

                row["Part_Number"] = item.Key;
                row["Drawing_File"] = item.Value;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static Dictionary<string, string> FindMatch()
        {

            Dictionary<string, string> matches = new Dictionary<string, string>();
            foreach (string part in LoadedDrawingList)
            {
                BatchUI.ProgressBarReference.Increment(BatchUI.ProgressBarReference.Step);
                if (!matches.Keys.Contains(part))
                {
                    string column = MainReference.DataGridReference.Columns[0].HeaderText.ToString();
                    string filter = $"{column} LIKE '{part}%'";
                    DataRow[] result = DrawingStorage.OPDrawingDataTable.Select(filter);
                    if (result.Length > 0)
                    {
                        matches.Add(part, result[0].Field<string>(column));
                    }
                    else
                    {
                        matches.Add(part, "Error; No Exact Match");
                    }
                }
            }

            
            return matches;

        }

        public static void PullMainSelectionToBatchCell()
        {
            IEnumerator<string> selectedMain = DrawingStorage.GetSelectedDrawings(MainReference.DataGridReference);
            if (selectedMain.MoveNext()) {
                DataGridViewCell cell = BatchUI.BatchDataGridReference.CurrentRow.Cells[1];
                if (cell.Value.ToString().Contains("Error") || cell.Value.ToString().Contains("*"))
                    cell.Value = $"{Path.GetFileName(selectedMain.Current)}*";
        
            }
        }

        private static void ProgressBarSetup()
        {
            BatchUI.BatchPrintStausLabelPreference.Text = "Processing Imports...";
            BatchUI.StatusStripReference.Update();
            BatchUI.ProgressBarReference.Visible = true;
            BatchUI.ProgressBarReference.Step = LoadedDrawingList.Count / 100;
            BatchUI.ProgressBarReference.Value = 0;
        }

        private static void ProgressBarTearDown()
        {
            BatchUI.ProgressBarReference.Visible = false;
            DataGridStatistics();
            BatchUI.BatchConfirmButtonReference.Enabled = true;
        }

        public static void Print()
        {
            Log.Write.Info("Batch Print Job Started.");

            BatchUI.BatchPrintButtonReference.Enabled = false;

            Printer.Process(BatchDataProcess());

            BatchUI.BatchConfirmButtonReference.Enabled = true;
        }

        public static IEnumerator<string> BatchDataProcess()
        {
            List<string> drawingNames = new List<string>();
            List<string> drawingPaths = new List<string>();

            foreach (DataGridViewRow row in BatchUI.BatchDataGridReference.Rows)
            {
                string cell = row.Cells[1].Value.ToString();
                if (cell.EndsWith(".dwg", StringComparison.CurrentCultureIgnoreCase) || cell.EndsWith(".edrw", StringComparison.CurrentCultureIgnoreCase))
                    drawingNames.Add(cell);
            }

            //Clears filter on datagrid to allow for all drawings to be queried against.
            MainReference.FilterTextBoxReference.Text = string.Empty;
            Search.Filter(MainReference.StartsWithCheckBoxReference.Checked, MainReference.FilterTextBoxReference.Text);

            foreach (string item in drawingNames)
            {
                DataGridViewRow row = MainReference.DataGridReference.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(item, StringComparison.CurrentCultureIgnoreCase))
                    .First();
                    
                drawingPaths.Add(row.Cells[1].Value.ToString());
            }


            return DrawingStorage.DrawingListConvertToEnumerator(drawingPaths);
        }

        public static void DataGridStatistics()
        {
            BatchUI.BatchPrintStausLabelPreference.Text = $"Errors Found: {ErrorCount().ToString()}";
            BatchUI.StatusStripReference.Update();
        }

        private static int ErrorCount()
        {
            string column = $"{BatchUI.BatchDataGridReference.Columns[1].HeaderText.ToString()}";
            string filter = $"{column} LIKE 'Error%'";
            return BatchDataTable.Select(filter).Count();

        }

        public static void Confirm()
        {


            string text = $"There are {ErrorCount()} non-associated part numbers.\nThese are to be skipped and will NOT print.\n\nThe following printer is currently selected:\n{Printer.SelectedPrinter ?? Printer.PrinterSettings.PrinterName} \n\nWould you like to confirm this and continue?";
            string caption = "Confimation";
            DialogResult conf = MessageBox.Show(text: text, caption: caption, buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Question);
            if (conf.ToString() == "OK")
            {
                BatchUI.BatchConfirmButtonReference.Enabled = false;
                BatchUI.BatchPrintButtonReference.Enabled = true;
            }
            else
            {
                Log.Write.Info("Batch Print Job Cancelled.");
            }
                
        }

    }


}
