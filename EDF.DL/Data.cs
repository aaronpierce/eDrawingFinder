using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using EDF.Common;
using System.Configuration;
using Microsoft.Win32;

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

        public static string GetEDrawingsExecutable()
        {
            string installDir = string.Empty;
            int year = DateTime.Today.Year + 1;
            while (string.IsNullOrEmpty(installDir))
            {
                Log.Write.Debug($"Checking for eDrawings {year}");
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\eDrawings\e{year}"))
                {
                    if (key != null)
                    {
                        installDir = Path.Combine((string)key.GetValue("InstallDir"), "eDrawings.exe");
                        Log.Write.Info($"eDrawing {year} install path found. {installDir}");
                    }
                }

                if (string.IsNullOrEmpty((installDir)) && year == 2018)
                {
                    Log.Write.Info($"No eDrawings installation >= 2018");
                    break;
                }

                year--;
            }

            return installDir;
        }

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
