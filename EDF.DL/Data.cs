using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using EDF.Common;
using System.Configuration;

namespace EDF.DL
{
    /// <summary>
    /// Class to reference loading/saving data
    /// </summary>
    public static class Data
    {
    
        static Data()
        {

            // Establishing disk file paths
            string appDataFolder = Environment.GetEnvironmentVariable("LOCALAPPDATA");
            string programAppDataFolder = Path.Combine(appDataFolder, "eDrawingFinder");

            if (!Directory.Exists(programAppDataFolder))
            {
                Directory.CreateDirectory(programAppDataFolder);
            }

            ProgramFolder = programAppDataFolder;
        }

        public static string ProgramFolder { get; }

        public static bool UpdatePending { get; set; } = false;

        public static IEnumerable<string> BatchPrintLoadFile(bool isCSVFile, string filename)
        {
            List<string> drawings = new List<string>();

            using (StreamReader fileReader = new StreamReader(filename))
            using (CsvReader csvReader = new CsvReader(fileReader))
            {
                if (!isCSVFile)
                {
                    string line = string.Empty;
                    string cleaned = string.Empty;

                    while ((line = fileReader.ReadLine()) != null)
                    {
                        cleaned = line.TrimEnd(',').Trim();
                        drawings.Add(cleaned);
                    }
                }
                else
                {
                    while (csvReader.Read())
                    {
                        drawings.Add(csvReader.GetField<string>(0));
                    }
                }

            }

            return drawings;

        }




    }
}
