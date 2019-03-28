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
        public static void Load()
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


        public static IEnumerator<string> GetSelectedDrawings()
        {
            List<string> items = new List<string>();
            foreach (DataGridViewTextBoxCell item in MainReference.DataGridReference.SelectedCells)
            {
                if (item.ColumnIndex == 2)
                {
                    if (item.RowIndex >= 0)
                    {
                        items.Add(item.Value.ToString());
                    }
                }
            }

            // Gets an enumearator from selected data grid items and sends those into the printer functions
            return ListToEnum.Convert(items);

        }

        public static int CountOfSelection() => MainReference.DataGridReference.SelectedRows.Count;
        public static bool SelectionLessThanOrEqual(int cap) => (CountOfSelection() <= cap) ? true : false;

    }

}
