using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingsPrinter
{
    class Search
    {
        public static CheckBox StartsWithCheckBoxReference { get; set; }
        public static TextBox FilterTextBoxReference { get; set; }

        // Filters datagrid on filename by given textbox value on button click.
        public static void Filter(bool checkBox, string filterText)
        {
            // If startswith check box is checked, place '' in front of the filtering text instead of '%'.
            string startsWith = checkBox == true ? "" : "%";

            // Takes first column name and applies to a filter string
            string filter = $"{DataGrid.DataGridReference.Columns[0].HeaderText.ToString()} LIKE '{startsWith}{filterText}%'";

            DrawingStorage.OPDrawingDataTable.DefaultView.RowFilter = filter;
            DrawingStorage.BMDrawingDataTable.DefaultView.RowFilter = filter;
            DataGrid.DataGridReference.Sort(DataGrid.DataGridReference.Columns["Path"], ListSortDirection.Ascending);
        }
    }
}
