using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDrawingsPrinter
{
    public class EDrawings
    {

        public EDrawings()
        {
            Control = new eDrawingHostControl.eDrawingControl();
        }
        public eDrawingHostControl.eDrawingControl Control { get; set; }
        public bool IsPrinting { get; set; } = false;
    }
}

