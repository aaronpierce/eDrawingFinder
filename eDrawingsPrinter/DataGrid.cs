using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
{
    class DataGrid
    {
        public static void Load()
        {
            // Calling this loads json data to disk, converts from dictionary to data table and updates DrawingDataTable.
            DrawingStorage.SetDataTable();

            if (Data.UpdateAvailable)
            {
                Data.UpdateAvailable = false;
            }
            else
            {
                DrawingStorage.CurrentDataTable = DrawingStorage.OPDrawingDataTable;
                // Uses the just updated variable DrawingDataTable as the data source for grid view.
                MainUI.DataGridReference.DataSource = DrawingStorage.CurrentDataTable;
            }


        }
    }
}
