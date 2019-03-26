using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using EDF.Common;
using EDF.DL;

namespace EDF.BL
{
    public static class DirectoryScan
    {
        // Variable used to store data from directory scans
        public static Dictionary<string, string> FileStorage;
        private static List<Drawing> opDrawings;
        private static List<Drawing> bmDrawings;
        private static List<Drawing> CoreDrawingList;
        //private static int Counter;

        public static void DirectorySearch()
        {
            
            opDrawings = new List<Drawing>();
            bmDrawings = new List<Drawing>();
            Log.Write.Info("Starting OP Scan");
            //Counter = 0;
            Process(opDrawings, @"\\pokydata1\CAD\DWG", DrawingGroup.OP, new List<string>() { "BM" });
            Log.Write.Info("Starting BM Scan");
            //Counter = 0;
            Process(bmDrawings, @"\\pokydata1\CAD\DWG\BM", DrawingGroup.BM, new List<string>() { "" });
            Log.Write.Info("Writting to DB");
            SqliteDataAccess.SaveDrawings(opDrawings);
            SqliteDataAccess.SaveDrawings(bmDrawings);
        }

        private static void Process(List<Drawing> drawingList, string parentDirectory, DrawingGroup group, List<string> exclusions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            GetDBData(drawingList, parentDirectory, group.ToString(), exclusions);
            stopWatch.Stop();
            Log.Write.Info($"DirSeach [Group: {group.ToString()} Time: {stopWatch.Elapsed} Count: {drawingList.Count}]");
        }

        public static void GetDBData(List<Drawing> drawingList, string parentDirectory, string group, List<string> exclusions)
        {
            //Counter++;
            string parentFilename = Path.GetFileName(parentDirectory);
            

            List<string> subPaths = new List<string>(Directory.EnumerateDirectories(path: parentDirectory));
            List<string> subFiles = new List<string>(Directory.EnumerateFiles(path: parentDirectory));

            // File get added to dictionary as "File = Filepath"
            foreach (string file in subFiles)
            {
                if ((file.EndsWith("dwg", StringComparison.CurrentCultureIgnoreCase) || file.EndsWith("edrw", StringComparison.CurrentCultureIgnoreCase)))
                {
                    drawingList.Add(new Drawing(){
                        File = Path.GetFileName(file),
                        Path = file,
                        Group = group
                        }
                    );
                }
            }

            // Directories get sent back through main scanning function to be broken down further
            foreach (string path in subPaths)
            {
                if (!(exclusions.Contains(Path.GetFileName(path))))
                {
                    GetDBData(drawingList, path, group, exclusions);
                }
            }

            return;
        }

        // Main directory scanning function that updates the FileStorage dictionary
        private static void GetDWGFiles(string parentDirectory, List<string> exclusions)
        {
            string parentFilename = Path.GetFileName(parentDirectory);

            List<string> subPaths = new List<string>(Directory.EnumerateDirectories(path: parentDirectory));
            List<string> subFiles = new List<string>(Directory.EnumerateFiles(path: parentDirectory));

            // File get added to dictionary as "File = Filepath"
            foreach (string file in subFiles)
            {
                if (!(FileStorage.ContainsKey(Path.GetFileName(file))) && (file.EndsWith("dwg", StringComparison.CurrentCultureIgnoreCase) || file.EndsWith("edrw", StringComparison.CurrentCultureIgnoreCase)))
                {
                    FileStorage.Add(Path.GetFileName(file), file);
                }
            }

            // Directories get sent back through main scanning function to be broken down further
            foreach (string path in subPaths)
            {
                if (!(exclusions.Contains(Path.GetFileName(path))))
                {
                    GetDWGFiles(path, exclusions);
                }
            }

        }

        // Facilitates directory scanning by clearing storage dictionary, and sends save method.
        public static void DirectorySearch(string parentDirectory, List<string> exclusions, DrawingGroup group)
        {
            FileStorage = new Dictionary<string, string>();
            Stopwatch stopWatch = Stopwatch.StartNew();
            GetDWGFiles(parentDirectory, exclusions);
            stopWatch.Stop();
            Log.Write.Info($"DirSeach [Group: {group.ToString()} Time: {stopWatch.Elapsed} Count: {FileStorage.Keys.Count}]");
            Data.SaveJson(FileStorage, group);
        }

        public static void PreCheckDataGridLoad()
        {
            // If either dont exists, tell the user whats happening.
            if (!File.Exists(Data.OPDrawingDataFile) || !File.Exists(Data.BMDrawingDataFile))
            {
                PreLoadMessage.ShowMessageBox("Database being created. This is a one time process.\n\nExit this window once the application starts.", "Please Wait.");
            }


            if (!File.Exists(Data.OPDrawingDataFile))
            {
                List<string> exclusions = new List<string> { "BM" };
                DirectoryScan.DirectorySearch(@"\\pokydata1\CAD\DWG", exclusions, DrawingGroup.OP);
            }

            if (!File.Exists(Data.BMDrawingDataFile))
            {
                List<string> exclusions = new List<string> { "" };
                DirectoryScan.DirectorySearch(@"\\pokydata1\CAD\DWG\BM", exclusions, DrawingGroup.BM);
            }

            //Thread t = new Thread(() => PostDataGridLoad());
            //t.Start();
        }

    }
}
