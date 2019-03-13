using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;

namespace eDrawingsPrinter
{
    class DrawingStorage
    {
        // Return Enumuerator from selected drawings in DataGridView
        public static IEnumerator<string> DataGridDrawings(List<string> list)
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


        // Storage loacation for drawing json files.
        private static string filepath = @"C:\Users\apierce\Desktop\filepaths.json";

        // Function for saving directory scan results to disk as json file.
        public static void SaveJson(Dictionary<string, string> drawingDictionary)
        {
            using (StreamWriter file = new StreamWriter(filepath, false))
            {
                file.Write(JsonConvert.SerializeObject(drawingDictionary, Formatting.Indented));
            }
        }

        // Function to load json from disk to dictionary.
        public static Dictionary<string, string> LoadJson()
        {
            using (StreamReader file = new StreamReader(filepath))
            {
                Dictionary<string, string> pathDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
                return pathDictionary;
            }
        }

        // Converts loaded dictionary to data table for use in data grid view
        private static DataTable ConvertToDataTable()
        {
            IEnumerable<Drawing> DrawingDataSource = from row in DrawingStorage.LoadJson() select new Drawing() { FileName = row.Key, FilePath = row.Value };

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
        public static DataTable DrawingDataTable { get; set; }

        // Calling this updates the data drawing table with json file.
        public static void SetDataTable()
        {
            DrawingDataTable = ConvertToDataTable();
        }

    }
}
