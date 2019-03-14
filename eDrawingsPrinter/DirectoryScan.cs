﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace eDrawingFinder
{
    public static class DirectoryScan
    {
        // Variable used to store data from directory scans
        public static Dictionary<string, string> FileStorage;


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

        public static void DirectorySearch(string parentDirectory, List<string> exclusions, Data.DrawingGroup group)
        {
            FileStorage = new Dictionary<string, string>();
            Stopwatch stopWatch = Stopwatch.StartNew();
            GetDWGFiles(parentDirectory, exclusions);
            stopWatch.Stop();
            Log.Write.Info($"DirSeach [Group: {group.ToString()} Time: {stopWatch.Elapsed} Count: {FileStorage.Keys.Count}]");
            Data.SaveJson(FileStorage, group);
        }
        
    }
}
