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
using System.Text.RegularExpressions;

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

        private static List<EDrawingInstall> GetEDrawingsInstallations()
        {
            List<EDrawingInstall> installations = new List<EDrawingInstall>();
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (subkey.GetValue("DisplayName") != null)
                        {
                            if (subkey.GetValue("DisplayName").ToString().Contains("eDrawing"))
                            {
                                installations.Add(new EDrawingInstall {
                                    Name = subkey.GetValue("DisplayName").ToString(),
                                    Install = subkey.GetValue("InstallLocation").ToString(),
                                    Year = EDrawingInstall.GetYear(subkey.GetValue("DisplayName").ToString())
                                });
                            }
                        }
                    }
                }
            }

            return installations;
        }

        public static string GetMostRecentEDrawingInstall()
        {
            List<EDrawingInstall> installations = GetEDrawingsInstallations();
            EDrawingInstall newest = new EDrawingInstall();
            foreach (EDrawingInstall install in installations)
            {
                if (install.Year > (int)newest.Year)
                    newest = install;
            }

            return newest.FullPath;
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

    class EDrawingInstall
    {
        public string Name { get; set; }
        public string Install { get; set; }
        public int Year { get; set; }

        public string FullPath {
            get {
                return Path.Combine(Install, "eDrawings.exe");
                    }
        }

        private static Regex YearRegex { get; set; } = new Regex(@"(19|20)\d{2}");

        public static int GetYear(string install)
        {
            Match regMatch = YearRegex.Match(install);
            return (regMatch.Success) ? Int32.Parse(regMatch.Value.ToString()) : 0;
        }
    }
}
