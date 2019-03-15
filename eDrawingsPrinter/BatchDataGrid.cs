using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingFinder
{
    class BatchDataGrid
    {
        public static DataGridView BatchDataGridReference { get; set; }
        public static DataTable BatchDataTable { get; set; }
        public static List<string> LoadedDrawingList { get; set; }
        public static Dictionary<string, string> MatchedDrawings { get; set; }

        public static void Load()
        {


        }

        public static void SetInputIntoGrid()
        {
            MatchedDrawings = FindMatch();
            BatchDataTable = ConvertToDataTable(MatchedDrawings);
            BatchDataGridReference.DataSource = BatchDataTable;
        }

        private static DataTable ConvertToDataTable(Dictionary<string, string> MatchedDrawings)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Part Number");
            dt.Columns.Add("Drawing File");

            foreach (KeyValuePair<string, string> item in MatchedDrawings)
            {
                DataRow row = dt.NewRow();

                row["Part Number"] = item.Key;
                row["Drawing File"] = item.Value;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static Dictionary<string, string> FindMatch()
        {
            Dictionary<string, string> matches = new Dictionary<string, string>();
            foreach (string part in LoadedDrawingList)
            {
                if (!matches.Keys.Contains(part))
                {
                    string column = DataGrid.DataGridReference.Columns[0].HeaderText.ToString();
                    string filter = $"{column} LIKE '{part}%'";
                    DataRow[] result = DrawingStorage.OPDrawingDataTable.Select(filter);
                    if (result.Length > 0)
                    {
                        matches.Add(part, result[0].Field<string>(column));
                    }
                    else
                    {
                        matches.Add(part, "Error; No Exact Match");
                    }
                }
            }
            return matches;

        }
    }
}
