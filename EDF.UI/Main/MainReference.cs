using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    class MainReference
    {
        public static ToolStripMenuItem SendToBatchDataGridContextMenuStripReference {get; set;}
        public static TextBox PreviewNameTextBoxRefernce {get; set;}
        public static TextBox PreviewLastModifiedTextBoxReference {get; set;}
        public static TextBox PreviewRevisionTextBoxReference{get; set;}
        public static ToolStripComboBox PrinterSelectionComboBoxReference {get; set;}
        public static CheckBox StartsWithCheckBoxReference {get; set;}
        public static TextBox FilterTextBoxReference {get; set;}
        public static DataGridView DataGridReference {get; set;}
        public static ToolStripProgressBar PrintingToolStripBarReference { get; set; }
    }
}
