using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
{
    public static class Data
    {
        // Class to reference loading/saving data
        static Data()
        {

            // Establishing disk file paths
            string appDataFolder = Environment.GetEnvironmentVariable("LOCALAPPDATA");
            string programAppDataFolder = Path.Combine(appDataFolder, "eDrawingFinder");
            string opDrawingDataFile = Path.Combine(programAppDataFolder, "OPDrawingPaths.json");
            string bmDrawingDataFile = Path.Combine(programAppDataFolder, "BMDrawingPaths.json");

            if (!Directory.Exists(programAppDataFolder))
            {
                Directory.CreateDirectory(programAppDataFolder);
            }

            ProgramFolder = programAppDataFolder;
            OPDrawingDataFile = opDrawingDataFile;
            BMDrawingDataFile = bmDrawingDataFile;

        }

        public static string ProgramFolder { get; }
        public static string OPDrawingDataFile { get; }
        public static string BMDrawingDataFile { get; }

        // If the required json files don't exists, make them.
        public static void PreCheckDataGridLoad()
        {
            // If either dont exists, tell the user whats happening.
            if (!File.Exists(OPDrawingDataFile) || !File.Exists(BMDrawingDataFile))
            {
                PreLoadMessage.ShowMessageBox("Database being created. This is a one time process.\n\nExit this window once the application starts.", "Please Wait.");
            }


            if (!File.Exists(OPDrawingDataFile))
            {
                List<string> exclusions = new List<string> { "BM" };
                DirectoryScan.DirectorySearch(@"H:\DWG", exclusions, DrawingGroup.OP);
            }

            if (!File.Exists(BMDrawingDataFile))
            {
                List<string> exclusions = new List<string> { "" };
                DirectoryScan.DirectorySearch(@"H:\DWG\BM", exclusions, DrawingGroup.BM);
            }

            // Loads json files to Data Grid for UI 
            DataGrid.Load();

            //Thread t = new Thread(() => PostDataGridLoad());
            //t.Start();
        }

        public static bool UpdateAvailable { get; set; } = false;

        // Runs every start after the inital loading to update datasets everytime.
        public static void PostDataGridLoad()
        {
            List<string> exclusions = new List<string> { "BM" };
            DirectoryScan.DirectorySearch(@"H:\DWG", exclusions, DrawingGroup.OP);

            exclusions = new List<string> { "" };
            DirectoryScan.DirectorySearch(@"H:\DWG\BM", exclusions, DrawingGroup.BM);

            // Tells program an updated set of files are available
            UpdateAvailable = true;

            // Reloads DataGrid from disk
            DataGrid.Load();
        }

        // Function for saving directory scan results to disk as json file.
        public static void SaveJson(Dictionary<string, string> drawingDictionary, DrawingGroup group)
        {
            string datafile = (group == DrawingGroup.OP) ? OPDrawingDataFile : BMDrawingDataFile;
            using (StreamWriter file = new StreamWriter(datafile, false))
            {
                file.Write(JsonConvert.SerializeObject(drawingDictionary, Formatting.Indented));
            }
        }

        // Function to load json from disk to dictionary.
        public static Dictionary<string, string> LoadJson(DrawingGroup group)
        {
            string datafile = (group == DrawingGroup.OP) ? OPDrawingDataFile : BMDrawingDataFile;
            using (StreamReader file = new StreamReader(datafile))
            {
                Dictionary<string, string> pathDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
                return pathDictionary;
            }
        }

        public static OpenFileDialog OpenFileDialog { get; set; } = OpenFileDialog = new OpenFileDialog()
        {
            FileName = "Select a file",
            Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*", 
            Title = "Open A List of Drawings"
        };

        public static void BatchPrintLoadFile()
        {
            List<string> drawings = new List<string>();

            OpenFileDialog.ShowDialog();

            using (StreamReader reader = new StreamReader(OpenFileDialog.FileName))
            {
                string line = string.Empty;
                string cleaned = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    cleaned = line.Trim();
                    drawings.Add(cleaned);
                }
            }

            BatchDataGrid.LoadedDrawingList = drawings;

        }


        // Helper enum to distinguish which data set is being worked with
        public enum DrawingGroup
        {
            OP,
            BM
        };

    }
}
