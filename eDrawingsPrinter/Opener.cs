using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace eDrawingFinder
{
    class Opener
    {
        public static void PreProcess()
        {
            if ((MainUI.DataGridReference.AreAllCellsSelected(true)) && (!DrawingStorage.SelectionLessThanOrEqual(10)))
            {
                Error();
            }
            else if (!DrawingStorage.SelectionLessThanOrEqual(10))
            {
                Error();
            }
            else
            {
                IEnumerator<string> list = DrawingStorage.GetSelectedDrawings(MainUI.DataGridReference);
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
