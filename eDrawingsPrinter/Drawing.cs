using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDrawingFinder
{
    // Object used to store Filename and Path information of a single DWG file.
    public class Drawing
    { 
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
