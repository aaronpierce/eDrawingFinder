﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDrawingsPrinter
{
    public static class Data
    {
        static Data()
        {
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

        public static void PreCheckDataGridLoad()
        {
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

        public enum DrawingGroup
        {
            OP,
            BM
        };

    }
}