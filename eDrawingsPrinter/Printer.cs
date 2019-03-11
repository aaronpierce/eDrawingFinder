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
        private static PrinterSettings printerSettings = new PrinterSettings();
        private static bool EventsHandled { get; set; }  = false;

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

        public static void Process(IEnumerator<string> DrawingList)
        {
            DrawingList.MoveNext();

            MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingList.Current, true, false, true, "");

            HandleEvents(DrawingList);
        }

        private static void HandleEvents(IEnumerator<string> DrawingList)
        {
            if (!EventsHandled) {
                MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument += (string fileName) =>
                {
                    Console.WriteLine("{0} finished loading.", fileName);
                    Print(filename: fileName, pdf: true);
                    Console.WriteLine("{0} printed.", fileName);
                };

                MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument += (string fileName) =>
                {

                    Console.WriteLine("{0} finished printing.", fileName);
                    MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");
                    Console.WriteLine("{0} closed.", fileName);


                    if (DrawingList.MoveNext())
                    {
                        MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingList.Current, true, false, true, "");
                    }
                    else
                    {
                        MainForm.eDrawings.IsPrinting = false;
                        Console.WriteLine("Process Complete.");
                    }
                };

                EventsHandled = true;
            }
        }
    }
}
