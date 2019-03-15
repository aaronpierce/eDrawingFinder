using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDrawingFinder
{
    public class EDrawings
    {
        // Creates eDrawingHostControl for providing eDrawing functions.
        public EDrawings()
        {
            Control = new eDrawingHostControl.eDrawingControl();
            PreviewControl = new eDrawingHostControl.eDrawingControl();

            
        }
        // Main control used for opening/printing files.
        public eDrawingHostControl.eDrawingControl Control { get; set; }

        // Secondary control utilized for preview files on the side of UI
        public eDrawingHostControl.eDrawingControl PreviewControl { get; set; }
    }
}

