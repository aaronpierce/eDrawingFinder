using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
{
    public static class Preview
    {
        public static void ShowDrawing()
        {
            Console.WriteLine(MainForm.eDrawings.Control.eDrawingControlWrapper.FileName);
            MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");

            IEnumerator<string> selected = DrawingStorage.GetSelectedDrawings(DataGrid.DataGridReference);
            selected.MoveNext();
            Current = selected.Current;
            MainForm.eDrawings.PreviewControl.eDrawingControlWrapper.OpenDoc(Current, false, false, false, "");
        }

        public static void Expand()
        {
            if (MainFormExpanded)
            {
                Program.MainFormReference.Width -= 365;
                MainFormExpanded = false;
            }
            else
            {
                Program.MainFormReference.Width += 365;
                MainFormExpanded = true;
            }
        }

        public static bool MainFormExpanded { get; set; } = true;

        private static string Current { get; set; }
    }
}
