using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDF.DL;

namespace EDF.UI
{
    class BatchFileLoad
    {
        private static OpenFileDialog OpenFileDialog { get; set; } = OpenFileDialog = new OpenFileDialog()
        {
            FileName = "Select a file",
            Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv",
            Title = "Open A List of Drawings"
        };

        public static void Get()
        {
            OpenFileDialog.ShowDialog();

            bool isCSVFile = Path.GetExtension(OpenFileDialog.FileName).Equals(".csv") ? true : false;

            List<string> drawings = new List<string>();

            BatchUI.BatchFileTextBoxReference.Text = OpenFileDialog.FileName;

            drawings = Data.BatchPrintLoadFile(isCSVFile, OpenFileDialog.FileName).ToList();

            BatchDataGrid.LoadedDrawingList = drawings;

        }
    }
}
