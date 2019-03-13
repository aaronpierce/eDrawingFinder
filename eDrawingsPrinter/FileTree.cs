using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace eDrawingsPrinter
{
    class FileTree
    {
        // Variable used to store data from directory scans
        public static Dictionary<string, string> FileStorage = new Dictionary<string, string>();

        // Varaible to hold a list of directories to not scan.
        public static List<string> exclusions = new List<String>() { "BM" };

        // Main directory scanning function that updates the FileStorage dictionary
        public static void GetDWGFiles(string parentDirectory)
        {
            string parentFilename = Path.GetFileName(parentDirectory);
            Console.WriteLine($"\n====== Parent Path : {Path.GetFileName(parentDirectory)} ======");

            List<string> subPaths = new List<string>(Directory.EnumerateDirectories(path: parentDirectory));
            List<string> subFiles = new List<string>(Directory.EnumerateFiles(path: parentDirectory));

            // File get added to dictionary as "File = Filepath"
            foreach (string file in subFiles)
            {
                string filename = Path.GetFileName(file);
                if (!(FileStorage.ContainsKey(filename)))
                {
                    FileStorage.Add(Path.GetFileName(file), file);
                }
            }

            // Directories get sent back through main scanning function to be broken down further
            foreach (string path in subPaths)
            {
                string pathname = Path.GetFileName(path);
                if (!(exclusions.Contains(pathname)))
                {
                    GetDWGFiles(path);
                }
            }

        }

       // Returns count of FileStorage dictionary, and calls save json to persist the data
        public static void CheckDictionary() {
            Console.WriteLine($"\n\nCount of Dictionary: {FileStorage.Keys.Count}");

            DrawingStorage.SaveJson(FileStorage);

            Console.WriteLine("Data stored.");
        }
        
    }
}
