using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDrawingFinder
{
    public class EDrawings
    {
        // class that creates the eDrawingHostControl for providing printing functions.
        public EDrawings()
        {
            Control = new eDrawingHostControl.eDrawingControl();
            PreviewControl = new eDrawingHostControl.eDrawingControl();

            
        }
        public eDrawingHostControl.eDrawingControl Control { get; set; }
        public eDrawingHostControl.eDrawingControl PreviewControl { get; set; }
    }
}

