using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Windows.Forms;

namespace eDrawingFinder
{
    class DrawingStorage
    {
        // Return Enumuerator from selected drawings in DataGridView
        public static IEnumerator<string> DrawingListConvertToEnumerator(List<string> list)
        {
            foreach (string item in list) { yield return item; }
        }

        /*
         *** This was used to load text file and print given drawings.
        private static IEnumerator<string> LoadDrawings(string filepath)
        {
            List<string> drawingList = File.ReadAllLines(filepath).ToList();

            foreach (string item in drawingList)
            {
                yield return "H:\\DWG\\OP232\\" + item;
            }
        }
        public static IEnumerator<string> DrawingList = LoadDrawings(@"C:\Users\apierce\Desktop\test\list.txt");
        */
        
        // Converts loaded dictionary to data table for use in data grid view
        private static DataTable ConvertToDataTable(Data.DrawingGroup drawingGroup)
        {
            IEnumerable<Drawing> DrawingDataSource = from row in Data.LoadJson(drawingGroup) select new Drawing() { FileName = row.Key, FilePath = row.Value };

            DataTable dt = new DataTable();
            dt.Columns.Add("File");
            dt.Columns.Add("Path");

            foreach (var item in DrawingDataSource)
            {
                var row = dt.NewRow();

                row["File"] = item.FileName;
                row["Path"] = item.FilePath;

                dt.Rows.Add(row);
            }

            return dt;
        }

        // Data table varibale used by data grid view
        public static DataTable OPDrawingDataTable { get; set; }
        public static DataTable BMDrawingDataTable { get; set; }

        // Calling this updates the data drawing table with json file.
        public static void SetDataTable()
        {
            OPDrawingDataTable = ConvertToDataTable(Data.DrawingGroup.OP);
            BMDrawingDataTable = ConvertToDataTable(Data.DrawingGroup.BM);
        }

        // Returns items that have been selected in the UI Data Grid
        public static IEnumerator<string> GetSelectedDrawings(DataGridView dgv)
        {
            List<string> items = new List<string>();
            foreach (DataGridViewTextBoxCell item in dgv.SelectedCells)
            {
                if (item.ColumnIndex == 1)
                {
                    items.Add(item.Value.ToString());
                }
            }

            // Gets an enumearator from selected data grid items and sends those into the printer functions
            IEnumerator<string> DrawingList = DrawingListConvertToEnumerator(items);

            return DrawingList;
        }

    }
}
