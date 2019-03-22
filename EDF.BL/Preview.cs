using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace eDrawingFinder
{
    public static class Preview
    {

        // Takes the topmost selected drawing from data grid and sends to previewcontrol for displaying on sidebar
        public static void ShowDrawing()
        { 
            MainForm.eDrawings.Control.eDrawingControlWrapper.CloseActiveDoc("");

            IEnumerator<string> selected = DrawingStorage.GetSelectedDrawings(MainUI.DataGridReference);
            if (selected.MoveNext())
            {
                Current = selected.Current;

                MainUI.PreviewNameTextBoxRefernce.Text = Current.Split('\\').Last();

                MainUI.PreviewLastModifiedTextBoxReference.Text = File.GetLastWriteTime(Current).ToShortDateString();

                Match regMatch = VersionRegex.Match(Path.GetFileNameWithoutExtension(Current));
                MainUI.PreviewRevisionTextBoxReference.Text = (regMatch.Success) ? regMatch.Value.ToUpper() : "";

                MainForm.eDrawings.PreviewControl.eDrawingControlWrapper.OpenDoc(Current, false, false, false, "");
                MainForm.eDrawings.PreviewControl.eDrawingControlWrapper.ViewOperator = EModelView.EMVOperators.eMVOperatorPan;
            }
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
        private static Regex VersionRegex { get; set; } = new Regex(@"(r|R)[0-9]{1,2}$");
    }
}
