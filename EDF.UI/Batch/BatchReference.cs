using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    class BatchUI
    {
        public static Button BatchConfirmButtonReference {get; set;}
        public static Button BatchPrintButtonReference {get; set;}
        public static DataGridView BatchDataGridReference {get; set;}
        public static ToolStripProgressBar ProgressBarReference {get; set;}
        public static StatusStrip StatusStripReference {get; set;}
        public static ToolStripStatusLabel BatchPrintStausLabelPreference {get; set;}
        public static ToolStripMenuItem SendToBatchDataGridContextMenuStripRefernce { get; set; }
        public static TextBox BatchFileTextBoxReference { get; set; }
    }
}
