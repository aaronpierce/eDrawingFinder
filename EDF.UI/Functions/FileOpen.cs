using System.Collections.Generic;
using System.Diagnostics;
using EDF.Common;
using System.Windows.Forms;
using EDF.DL;

namespace EDF.UI
{
    public class FileOpen
    {
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
                    string eDrawingInstall = Data.GetEDrawingsExecutable();
                    Log.Write.Info($"eDrawingInstall - {eDrawingInstall}");
                    if (eDrawingInstall != "")
                    {
                        Log.Write.Debug($"eDrawingInstall Open");
                        Process.Start(eDrawingInstall, list.Current.Path);
                    }
                    else
                    {
                        Log.Write.Debug($"OS Open");
                        Process.Start(list.Current.Path);
                    }
                    StatusBar.UpdateMain($"File opened: {list.Current.File}");
                    Log.Write.Info($"File opened: {list.Current.Path}");
                }
            }
        }
    }
}
