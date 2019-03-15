using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
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

            // Applies filter to both data tables
            DrawingStorage.OPDrawingDataTable.DefaultView.RowFilter = filter;
            DrawingStorage.BMDrawingDataTable.DefaultView.RowFilter = filter;

            // Sets current data grid to ascending order by default
            DataGrid.DataGridReference.Sort(DataGrid.DataGridReference.Columns["Path"], ListSortDirection.Ascending);
        }
    }
}
