using System.Collections.Generic;
using System.Diagnostics;
using EDF.Common;
using System.Windows.Forms;
using EDF.DL;

namespace EDF.UI
{
    public class Opener
    {
        public static void PreProcess()
        {
            if ((MainReference.DataGridReference.AreAllCellsSelected(true)) && (!DataGrid.SelectionLessThanOrEqual(10)))
            {
                Error();
            }
            else if (!DataGrid.SelectionLessThanOrEqual(10))
            {
                Error();
            }
            else
            {
                IEnumerator<string> list = DrawingStorage.GetSelectedDrawings(MainReference.DataGridReference);
                while (list.MoveNext())
                {
                    Process.Start(list.Current.ToString());
                    Log.Write.Info($"File opened: {list.Current.ToString()}");
                }
            }
        }

        private static void Error()
        {
            MessageBox.Show("Too many files are currently selected.", "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
