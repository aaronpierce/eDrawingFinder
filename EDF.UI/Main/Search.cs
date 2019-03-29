using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDF.DL;
using EDF.Common;
using System.Diagnostics;

namespace EDF.UI
{
    public class Search
    {
        // Filters datagrid on filename by given textbox value on button click.
        public static List<EDF.DL.Drawing> Filter(bool startWithCheckBox, string filterText, bool OPCheckBox, bool BMCheckBox)
        {
            string whereGroup = string.Empty;

            if (!(OPCheckBox && BMCheckBox))
            {
                whereGroup = OPCheckBox ? DrawingGroup.OP.ToString() : DrawingGroup.BM.ToString();
            }


            // If startswith check box is checked, place '' in front of the filtering text instead of '%'.
            string startsWith = startWithCheckBox == true ? "" : "%";

            return SqliteDataAccess.LoadDrawings(filter:filterText, starts:startsWith, group:whereGroup);
        }

        public static bool Ready {
            get {
                if (!Data.UpdatePending)
                {
                    return true;
                }
                else
                {
                    StatusBar.UpdateMain("Database updating.");
                    return false;
                }
            }
        }
    }
}
