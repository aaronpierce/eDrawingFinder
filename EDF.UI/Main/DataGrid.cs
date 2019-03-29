using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDF.DL;
using EDF.Common;

namespace EDF.UI
{
    class DataGrid
    {
        public static void MainLoad()
        {
            MainReference.DataGridReference.DataSource = SqliteDataAccess.LoadAllDrawings();
            ApplyGridSettings();
        }

        private static void ApplyGridSettings()
        {
            MainReference.DataGridReference.Columns["Id"].Visible = false;
            MainReference.DataGridReference.Columns["File"].FillWeight = 90;
            MainReference.DataGridReference.Columns["Group"].Width = 50;
        }


        public static IEnumerator<IDrawing> GetSelectedDrawings(DataGridView DGV)
        {
            List<IDrawing> items = new List<IDrawing>();
            foreach (DataGridViewRow row in DGV.SelectedRows)
            {
                items.Add(new Drawing()
                {
                    File = row.Cells["File"].Value.ToString(),
                    Path = row.Cells["Path"].Value.ToString(),
                    Group = row.Cells["Group"].Value.ToString()

                });
            }

            // Gets an enumearator from selected data grid items and sends those into the printer functions
            return ListToEnum.Convert(items);

        }

        public static IDrawing GetFirstSelectedDrawing(DataGridView DGV)
        {
            Drawing returnDrawing = new Drawing() { File = "", Path = "", Group = "" };
            foreach (DataGridViewRow row in DGV.SelectedRows)
            {
                returnDrawing.File = row.Cells["File"].Value.ToString();
                returnDrawing.Path = row.Cells["Path"].Value.ToString();
                returnDrawing.Group = row.Cells["Group"].Value.ToString();
                break;
            }
            return returnDrawing;
        }

        public static int CountOfSelection(DataGridView DGV) => DGV.SelectedRows.Count;
        public static bool SelectionLessThanOrEqual(int cap, DataGridView DGV) => (CountOfSelection(DGV) <= cap) ? true : false;

    }

}
