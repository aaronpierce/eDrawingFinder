using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace eDrawingsPrinter
{
    class DrawingStorage
    {
        private static IEnumerator<string> LoadDrawings(string filepath)
        {
            List<string> drawingList = File.ReadAllLines(filepath).ToList();

            foreach (string item in drawingList)
            {
                yield return "H:\\DWG\\OP232\\" + item;
            }
        }

        public static IEnumerator<string> DrawingList = LoadDrawings(@"C:\Users\apierce\Desktop\test\list.txt");

        private static string filepath = @"C:\Users\apierce\Desktop\filepaths.json";
        public static void SaveJson(Dictionary<string, string> drawingDictionary)
        {
            using (StreamWriter file = new StreamWriter(filepath, false))
            {
                file.Write(JsonConvert.SerializeObject(drawingDictionary, Formatting.Indented));
            }
        }

        public static Dictionary<string, string> LoadJson()
        {
            using (StreamReader file =  new StreamReader(filepath))
            {
                Dictionary<string, string> pathDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
                return pathDictionary;
            }
        }

    }
}
