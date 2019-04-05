using EDF.Common;
using EDF.DL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace EDF.BL
{
    public static class DirectoryScan
    {
        private static List<Drawing> opDrawings;
        private static List<Drawing> bmDrawings;
        private static Task PostLoadUpdateTask { get; set; }  = new Task(() => PostLoadDatabaseUpdate());
        public static Task ManualLoadUpdateTask { get; set; } = new Task(() => PostLoadDatabaseUpdate(0));
        public static bool PostLoadComplete { get; set; } = false;
        private static bool DBFileExists { get; set; } = false;

        public static void DirectorySearch()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Task opTask = OPSearch();
            Task bmTask = BMSearch();

            Task.WaitAll(opTask, bmTask);

            stopwatch.Stop();
            Log.Write.Info($"Total directory scan took {stopwatch.Elapsed.Seconds}.{stopwatch.Elapsed.Milliseconds} seconds");

        }

        private static Task BMSearch()
        {
            bmDrawings = new List<Drawing>();
            Log.Write.Info("Starting BM directory scan");
            return Task.Run(() => Process(bmDrawings, @"\\pokydata1\CAD\DWG\BM", DrawingGroup.BM, new List<string>() { "" }));
        }

        private static Task OPSearch()
        {
            opDrawings = new List<Drawing>();
            Log.Write.Info("Starting OP directory scan");
            return Task.Run(() => Process(opDrawings, @"\\pokydata1\CAD\DWG", DrawingGroup.OP, new List<string>() { "BM" }));
            
        }

        private static Task Process(List<Drawing> drawingList, string parentDirectory, DrawingGroup group, List<string> exclusions)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            GetDBData(drawingList, parentDirectory, group.ToString(), exclusions);
            stopwatch.Stop();
            return Task.Run(() => Log.Write.Info($"Directory scan of {group.ToString()} took {stopwatch.Elapsed.Seconds}.{stopwatch.Elapsed.Milliseconds} seconds yielding {drawingList.Count} results"));
        }

        public static void GetDBData(List<Drawing> drawingList, string parentDirectory, string group, List<string> exclusions)
        {
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

        public static bool DatabaseExists()
        {

            if (File.Exists(SqliteDataAccess.LoadDatabaseName()))
            {
                Log.Write.Info("Database exists in precheck");
                DBFileExists = true;
                               
                if (SqliteDataAccess.IsTableEmpty())
                {
                    Log.Write.Info("Database exists but is empty in precheck");
                    SqliteDataAccess.ClearTable();
                    return false;
                }
                else
                {
                    PostLoadUpdateTask.Start();
                    return true;
                }

            }
            else
            {
                DBFileExists = false;
                return false;
            }

        }

        public static void PreLoadDatabase()
        {
            if (!DBFileExists)
                SQLiteConnection.CreateFile(SqliteDataAccess.LoadDatabaseName());

            SqliteDataAccess.BuildTable();
            DirectorySearch();
            WriteToDatabase();

        }
        public static void PostLoadDatabaseUpdate(int milliseconds = 30000)
        {
            PostLoadComplete = false;

            System.Threading.Thread.Sleep(milliseconds);

            Log.Write.Info("Starting PostLoad DirectoryScan for Database update");
            DirectorySearch();

            DatabaseProcessing();

            PostLoadComplete = true;
        }

        private static void DatabaseProcessing()
        {
            Log.Write.Info("Database update now pending");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Data.UpdatePending = true;
            SqliteDataAccess.ClearTable();
            SqliteDataAccess.BuildTable();

            WriteToDatabase();
            Data.UpdatePending = false;

            stopwatch.Stop();
            Log.Write.Info($"Database updated [Pending for {stopwatch.Elapsed.Seconds}.{stopwatch.Elapsed.Milliseconds} seconds]");
        }
        private static void WriteToDatabase()
        {
            Log.Write.Info("Writing to DB");
            SqliteDataAccess.SaveDrawings(opDrawings);
            SqliteDataAccess.SaveDrawings(bmDrawings);

            opDrawings = null;
            bmDrawings = null;
        }

    }
}
