﻿using System.Collections.Generic;
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
            if ((MainReference.DataGridReference.AreAllCellsSelected(true)) && (!DataGrid.SelectionLessThanOrEqual(10)))
            {
                MessageBoxes.TooManyFilesSelected("File Open Error");
            }
            else if (!DataGrid.SelectionLessThanOrEqual(10))
            {
                MessageBoxes.TooManyFilesSelected("File Open Error");
            }
            else
            {
                IEnumerator<string> list = DataGrid.GetSelectedDrawings();
                while (list.MoveNext())
                {
                    Process.Start(list.Current.ToString());
                    Log.Write.Info($"File opened: {list.Current.ToString()}");
                }
            }
        }
    }
}
