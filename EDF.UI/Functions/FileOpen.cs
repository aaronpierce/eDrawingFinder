using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using EDF.Common;

namespace EDF.UI
{
    public class FileOpen
    {
        public static string EDrawingsInstall { get; set; }
        public static void PreProcess()
        {
            if ((MainReference.DataGridReference.AreAllCellsSelected(true)) && (!DataGrid.SelectionLessThanOrEqual(10, MainReference.DataGridReference)))
            {
                MessageBoxes.TooManyFilesSelected("File Open Error");
            }
            else if (!DataGrid.SelectionLessThanOrEqual(10, MainReference.DataGridReference))
            {
                MessageBoxes.TooManyFilesSelected("File Open Error");
            }
            else
            {
                IEnumerator<IDrawing> list = DataGrid.GetSelectedDrawings(MainReference.DataGridReference);
                while (list.MoveNext())
                {
                    Thread.Sleep(500);
                    Log.Write.Info($"eDrawingInstall - {EDrawingsInstall}");
                    if (!string.IsNullOrEmpty(EDrawingsInstall))
                    {
                        try
                        {
                            Log.Write.Info($"Opening files using OS process");
                            Process.Start(EDrawingsInstall, list.Current.Path);
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            Log.Write.Info($"Using OS to open files. eDrawing install threw exception. {EDrawingsInstall}");
                            Process.Start(list.Current.Path);
                        } 
                    }
                    else
                    {
                        Log.Write.Info($"Opening files using OS");
                        Process.Start(list.Current.Path);
                    }
                    StatusBar.UpdateMain($"File opened: {list.Current.File}");
                    Log.Write.Info($"File opened: {list.Current.Path}");
                }
            }
        }
    }
}
