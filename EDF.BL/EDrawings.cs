using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    public class EDrawings
    {
        // Creates eDrawingHostControl for providing eDrawing functions.
        public EDrawings()
        {
            try
            {
                Control = new eDrawingHostControl.eDrawingControl();
                PreviewControl = new eDrawingHostControl.eDrawingControl();
                //throw new Exception("Test Exception for missing eDrawings installation.");
            }
            catch
            {
                MessageBox.Show("eDrawings 2018 Installation Not Found", "Error - Installation Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Control = null;
                PreviewControl = null;
            }
            
        }
        // Main control used for opening/printing files.
        public eDrawingHostControl.eDrawingControl Control { get; set; }

        // Secondary control utilized for preview files on the side of UI
        public eDrawingHostControl.eDrawingControl PreviewControl { get; set; }
    }
}

