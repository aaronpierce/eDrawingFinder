﻿using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using EDF.Common;

namespace EDF.DL
{
    public class DrawingStorage
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
        private static DataTable ConvertToDataTable(DrawingGroup drawingGroup)
        {
            Dictionary<string, string> DrawingDataSource = Data.LoadJson(drawingGroup);

            DataTable dt = new DataTable();
            dt.Columns.Add("File");
            dt.Columns.Add("Path");

            foreach (KeyValuePair<string, string> item in DrawingDataSource)
            {
                var row = dt.NewRow();

                row["File"] = item.Key;
                row["Path"] = item.Value;

                dt.Rows.Add(row);
            }

            return dt;
        }

        // Data table varibale used by data grid view
        public static DataTable OPDrawingDataTable { get; set; }
        public static DataTable BMDrawingDataTable { get; set; }
        public static DataTable CurrentDataTable { get; set; }

        // Calling this updates the data drawing table with json file.
        public static void SetDataTable()
        {
            OPDrawingDataTable = ConvertToDataTable(DrawingGroup.OP);
            BMDrawingDataTable = ConvertToDataTable(DrawingGroup.BM);
        }

        // Returns items that have been selected in the UI Data Grid
        public static IEnumerator<string> GetSelectedDrawings(DataGridView dgv)
        {
            List<string> items = new List<string>();
            foreach (DataGridViewTextBoxCell item in dgv.SelectedCells)
            {
                if (item.ColumnIndex == 1)
                {
                    if (item.RowIndex >= 0)
                    {
                        items.Add(item.Value.ToString());
                    }
                }
            }

            // Gets an enumearator from selected data grid items and sends those into the printer functions
            IEnumerator<string> DrawingList = DrawingListConvertToEnumerator(items);

            return DrawingList;
        }

    }
}