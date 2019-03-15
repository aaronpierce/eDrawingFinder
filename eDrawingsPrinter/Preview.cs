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

        // Takes the topmost selected drawing from data grid and sends to previewcontrol for displaying on sidebar
        public static void ShowDrawing()
        { 
            MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");

            IEnumerator<string> selected = DrawingStorage.GetSelectedDrawings(DataGrid.DataGridReference);
            selected.MoveNext();
            Current = selected.Current;
            MainForm.eDrawings.PreviewControl.eDrawingControlWrapper.OpenDoc(Current, false, false, false, "");
        }

        // If expanded == false, extend width, otherwise shrink width
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
