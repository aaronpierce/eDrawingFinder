using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using EDF.DL;
using EDF.Common;

namespace EDF.UI
{
    public class ContextClipboard
    {
        public static void CopyPartNumber(DataGridView DGV)
        {
            IEnumerator<IDrawing> drawings = DataGrid.GetSelectedDrawings(DGV);
            string items = string.Empty;
            while (drawings.MoveNext())
            {

                items += $"{Path.GetFileNameWithoutExtension(drawings.Current.Path)}\n";
            }

            Clipboard.SetText(items.Trim());

        }
        public static void CopyDrawingFileName(DataGridView DGV)
        {
            IEnumerator<IDrawing> drawings = DataGrid.GetSelectedDrawings(DGV);
            string items = string.Empty;
            while (drawings.MoveNext())
            {

                items += $"{drawings.Current.File}\n";
            }

            Clipboard.SetText(items.Trim());

        }
        public static void CopyFilePath(DataGridView DGV)
        {
            IEnumerator<IDrawing> drawings = DataGrid.GetSelectedDrawings(DGV);
            string items = string.Empty;
            while (drawings.MoveNext())
            {

                items += $"{drawings.Current.Path}\n";
            }

            Clipboard.SetText(items.Trim());

        }

        public static void OpenWithFileExplorer(DataGridView DGV)
        {
            IEnumerator<IDrawing> drawings = DataGrid.GetSelectedDrawings(DGV);

            HashSet<string> paths = new HashSet<string>();
            while (drawings.MoveNext())
            {
                paths.Add(drawings.Current.Path);
            }
            
            foreach (string path in paths)
            {
                //Process.Start(path);

                Process.Start("explorer.exe", $"/select, \"{path}\"");
            }
        }

        public static void BatchCopyPartNumber() => Clipboard.SetText(Path.GetFileNameWithoutExtension(BatchDataGrid.GetSelectedRowMatch().Part));

        public static void BatchCopyDrawingFileName() => Clipboard.SetText(BatchDataGrid.GetSelectedRowMatch().Drawing.File);

        public static void BatchCopyFilePath() => Clipboard.SetText(BatchDataGrid.GetSelectedRowMatch().Drawing.Path);

        public static void BatchOpenWithFileExplorer() => Process.Start("explorer.exe", $"/select, \"{BatchDataGrid.GetSelectedRowMatch().Drawing.Path}\"");

        public static void BatchOpenWithEDrawings() => Process.Start(BatchDataGrid.GetSelectedRowMatch().Drawing.Path);
    }
}
