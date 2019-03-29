using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.UI
{
    class StatusBar
    {
        public static void UpdateMain(string input)
        {
            MainReference.StatusStripStatusLabelReference.Text = input;
        }

        public static void UpdateBatch(string input)
        {
            BatchReference.BatchPrintStausLabelPreference.Text = input;
        }
    }
}
