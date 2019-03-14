using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace eDrawingFinder
{
    public class Printer
    {
        public static ToolStripComboBox PrinterSelectionComboBoxRefrence;
        public static void SetPrinterOptions()
        {
            PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;
            var printersList = new List<string>();
            foreach (string printer in printers)
            {
                printersList.Add(printer);
            }

            PrinterSelectionComboBoxRefrence.ComboBox.Items.Clear();
            PrinterSelectionComboBoxRefrence.ComboBox.Items.AddRange(printersList.ToArray<object>());

        }

        // Used to accss default printer settings on machine.
        private static PrinterSettings PrinterSettings = new PrinterSettings();

        public static string SelectedPrinter { get; set; }
   
        public static bool IsPrinting { get; set; } = false;

        // Set true after events are established upon first run.
        private static bool EventsHandled { get; set; }  = false;

        // Main print function that established page setup options and sends print command.
        private static void Print(string filename)
        {
            string printer = SelectedPrinter ?? PrinterSettings.PrinterName;

            // Sets page options
            MainForm.eDrawings.Control.eDrawingControlWrapper.SetPageSetupOptions(
                Orientation: EModelView.EMVPrintOrientation.eLandscape,
                PaperSize: 1,
                PaperLength: 0,
                PaperWidth: 0,
                Copies: 1,
                Source: 7,
                Printer: printer,
                TopMargin: 0,
                BottomMargin: 0,
                LeftMargin: 0,
                RightMargin: 0
                );

            // Sends print command
            MainForm.eDrawings.Control.eDrawingControlWrapper.Print5(
                ShowDialog: false,
                FileNameInPrintQueue: filename,
                Shaded: false,
                DraftQuality: false,
                Color: false,
                printType: EModelView.EMVPrintType.eScaleToFit,
                scale: 1,
                centerOffsetX: 0,
                centerOffsetY: 0,
                printAll: false,
                pageFirst: 1,
                pageLast: 1,
                PrintToFileName: ""
                );
        }

        // Starts chain of events for opening/printing/closing
        public static void Process(IEnumerator<string> DrawingList)
        {
            DrawingList.MoveNext();

            // Prints first file in list
            MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingList.Current, true, false, true, "");

            // Establishes the events needed for chain processing
            HandleEvents(DrawingList);
        }

        private static void HandleEvents(IEnumerator<string> DrawingList)
        {
            // If events have already been handled, skip this.
            if (!EventsHandled) {
                
                // Once the document is loaded, send it through the print function.
                MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument += (string fileName) =>
                {
                    Print(filename: fileName);
                };

                // Once printing is complete, send closeing function to document.
                MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument += (string fileName) =>
                {
                    Log.Write.Info($"Printed: {fileName}");
                    MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");


                    // If another file exists in list of drawings, move to the next, open it, and start chain of events.
                    if (DrawingList.MoveNext())
                    {
                        MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingList.Current, true, false, true, "");
                    }

                    // Otherwise, end printing jobs.
                    else
                    {
                        IsPrinting = false;
                    }
                };

                // Establish events were handled.
                EventsHandled = true;
            }
        }
    }
}
