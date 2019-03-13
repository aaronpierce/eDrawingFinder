using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace eDrawingsPrinter
{
    public class Printer
    {
        // Used to accss default printer settings on machine.
        private static PrinterSettings printerSettings = new PrinterSettings();

        // Set true after events are established upon first run.
        private static bool EventsHandled { get; set; }  = false;

        // Main print function that established page setup options and sends print command.
        private static void Print(string filename, bool pdf)
        {
            string printer;

            if (pdf == true)
            {
                printer = "Foxit Reader PDF Printer";
            }
            else
            {
                printer = printerSettings.PrinterName;
            }

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
                    Console.WriteLine("{0} finished loading.", fileName);
                    Print(filename: fileName, pdf: false);
                    Console.WriteLine("{0} printed.", fileName);
                };

                // Once printing is complete, send closeing function to document.
                MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument += (string fileName) =>
                {

                    Console.WriteLine("{0} finished printing.", fileName);
                    MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");
                    Console.WriteLine("{0} closed.", fileName);


                    // If another file exists in list of drawings, move to the next, open it, and start chain of events.
                    if (DrawingList.MoveNext())
                    {
                        MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingList.Current, true, false, true, "");
                    }

                    // Otherwise, end printing jobs.
                    else
                    {
                        MainForm.eDrawings.IsPrinting = false;
                        Console.WriteLine("Process Complete.");
                    }
                };

                // Establish events were handled.
                EventsHandled = true;
            }
        }
    }
}
