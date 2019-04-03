using System.Collections.Generic;
using System.Linq;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Threading;
using EDF.DL;
using EDF.Common;
using System.IO;

namespace EDF.UI
{
    // Provides printer functionaility 
    public class FilePrint
    {
        // Used to accss default printer settings on machine.
        public static PrinterSettings PrinterSettings = new PrinterSettings();
        private static IEnumerator<IDrawing> DrawingListToPrint;
        public static string SelectedPrinter { get; set; }
        private static bool EventsHandled { get; set; } = false;
        private static bool IsPrinting { get; set; } = false;
        private static int PrintCounter { get; set; }
        private static int CountOfFiles { get; set; }
        //private static PrintProgressForm ProgressForm { get; set; }
        private static void UpdateStatus(string file, bool restart = false)
        {
            if (restart)
            {
                PrintCounter = 0;
            }
            PrintCounter++;
            StatusBar.UpdateMain($"Printing in Progress [{PrintCounter}/{CountOfFiles}]. Current File: {file}");
        }

        public static void PreProcess()
        {
            // If printing is in process, skip the printing processes from spawning again.
            if (!IsPrinting)
            {
                if ((MainReference.DataGridReference.AreAllCellsSelected(true)) && (!DataGrid.SelectionLessThanOrEqual(10, MainReference.DataGridReference)))
                {
                    MessageBoxes.TooManyFilesSelected("Print Error");
                }
                else if (!DataGrid.SelectionLessThanOrEqual(10, MainReference.DataGridReference))
                {
                    MessageBoxes.TooManyFilesSelected("Print Error");
                }
                else
                {
                    IsPrinting = true;
                    FilePrint.Process(DataGrid.GetSelectedDrawings(MainReference.DataGridReference), DataGrid.CountOfSelection(MainReference.DataGridReference));
                }
            }
        }

       
        // Filles PrinterSelectionComboBox with list of installed printers upon opening
        public static void SetPrinterOptions()
        {
            PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;
            var printersList = new List<string>();
            foreach (string printer in printers)
            {
                printersList.Add(printer);
            }

            MainReference.PrinterSelectionComboBoxReference.ComboBox.Items.Clear();
            MainReference.PrinterSelectionComboBoxReference.ComboBox.Items.AddRange(printersList.ToArray<object>());

            MainReference.PrinterSelectionComboBoxReference.SelectedItem = SelectedPrinter ?? PrinterSettings.PrinterName;
        }

        // Main print function that established page setup options and sends print command.
        private static void Print(string filename)
        {
            // If no printer is selected, use computer default
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
        public static void Process(IEnumerator<IDrawing> IncomingDrawingListToPrint, int IncomingTotalCount)
        {
            DrawingListToPrint = IncomingDrawingListToPrint;
            DrawingListToPrint.MoveNext();

            CountOfFiles = IncomingTotalCount;
            UpdateStatus(DrawingListToPrint.Current.File, true);

            // Prints first file in list
            MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingListToPrint.Current.Path, true, false, true, "");

            if (!EventsHandled)
                // Establishes the events needed for chain processing
                EstablishHandlerEvents();
        }

        private static void EstablishHandlerEvents()
        {
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument += EDrawingControlWrapper_OnFinishedLoadingDocument;
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument += EDrawingControlWrapper_OnFinishedPrintingDocument;
       }



        // Tested removing and adding events on every interaction. Current not in use. 
        private static void RemoveHandlerEvents()
        {
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedLoadingDocument -= EDrawingControlWrapper_OnFinishedLoadingDocument;
            MainForm.eDrawings.Control.eDrawingControlWrapper.OnFinishedPrintingDocument -= EDrawingControlWrapper_OnFinishedPrintingDocument;
        }

        // Once document fully loads, send it to print method
        private static void EDrawingControlWrapper_OnFinishedLoadingDocument(string FileName)
        {
            Print(filename: FileName);
        }

        // Once document finishes printing, close it, and move to the next document, if available.
        private static void EDrawingControlWrapper_OnFinishedPrintingDocument(string PrintJobName)
        {
            Log.Write.Info($"Printed: {PrintJobName}");
            MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");
            
            // If another file exists in list of drawings, move to the next, open it, and start chain of events.
            if (DrawingListToPrint.MoveNext())
            {
                UpdateStatus(DrawingListToPrint.Current.File);
                MainForm.eDrawings.Control.eDrawingControlWrapper.OpenDoc(DrawingListToPrint.Current.Path, true, false, true, "");
            }

            // Otherwise, end printing jobs.
            else
            {
                IsPrinting = false;
                StatusBar.UpdateMain("Printing Complete.");
                DrawingListToPrint = null;
                RemoveHandlerEvents();
            }
        }
    }
}
