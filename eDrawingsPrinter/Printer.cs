using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using EModelView;

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

        private static IEnumerator<string> DrawingListToPrint;

        public static string SelectedPrinter { get; set; }
   
        public static bool IsPrinting { get; set; } = false;

       


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
        public static void Process(IEnumerator<string> IncomingDrawingListToPrint)
        {
            DrawingListToPrint = IncomingDrawingListToPrint;
            DrawingListToPrint.MoveNext();

            // Prints first file in list
            MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingListToPrint.Current, true, false, true, "");

            // Establishes the events needed for chain processing
            EstablishHandlerEvents();
        }


        private static void EstablishHandlerEvents()
        {
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument += EDrawingControlWrapper_OnFinishedLoadingDocument;
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument += EDrawingControlWrapper_OnFinishedPrintingDocument;
        }

        private static void RemoveHandlerEvents()
        {
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument -= EDrawingControlWrapper_OnFinishedLoadingDocument;
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument -= EDrawingControlWrapper_OnFinishedPrintingDocument;
        }

        private static void EDrawingControlWrapper_OnFinishedLoadingDocument(string FileName)
        {
            Print(filename: FileName);
        }
        private static void EDrawingControlWrapper_OnFinishedPrintingDocument(string PrintJobName)
        {
            Log.Write.Info($"Printed: {PrintJobName}");
            MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");

            // If another file exists in list of drawings, move to the next, open it, and start chain of events.
            if (DrawingListToPrint.MoveNext())
            {
                MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingListToPrint.Current, true, false, true, "");
            }

            // Otherwise, end printing jobs.
            else
            {
                IsPrinting = false;
                DrawingListToPrint = null;
                RemoveHandlerEvents();
            }
        }
    }
}
