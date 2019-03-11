using System;
using System.Collections.Generic;
using System.IO;


namespace eDrawingsPrinter
{
    class FileTree
    {
        public static Dictionary<string, string> FileStorage = new Dictionary<string, string>();
        public static List<string> exclusions = new List<String>() { "BM", "202POG", "Biaplas", "Cad Blocks (Standard Product)", "Fastenal", "Installation Drawings", "Jigs", "Layout"};
        public static List<string> skipped = new List<string>();
        public static void Test(string parentDirectory)
        {
            string parentFilename = Path.GetFileName(parentDirectory);
            Console.WriteLine($"\n====== Parent Path : {Path.GetFileName(parentDirectory)} ======");

            List<string> subPaths = new List<string>(Directory.EnumerateFileSystemEntries(path: parentDirectory));

            if (!(subPaths.Count == 0) && !(exclusions.Contains(parentFilename)))
            {
                foreach (string path in subPaths)
                {
                    string filename = Path.GetFileName(path);
                    if (File.Exists(path))
                    {   
                        //Console.WriteLine($"File: {filename}");

                        if (!FileStorage.ContainsKey(filename))
                        {
                            FileStorage.Add(filename, path);
                        }
                        else
                        {
                            skipped.Add(path);
                        }
                    }
                    else if (Directory.Exists(path))
                    {
                        //Console.WriteLine($"Folder: {filename}");

                        Test(path);
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {filename}");
                    }
                }
            } else
            {
               //Console.WriteLine("**Empty Directory**");
            }
       
        }
        public static void CheckDictionary() {
            Console.WriteLine($"\n\nCount of Dictionary: {FileStorage.Keys.Count}");

            DrawingStorage.SaveJson(FileStorage);

            Console.WriteLine("Data stroed.");
        }
        
    }
}
