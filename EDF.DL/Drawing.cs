using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDF.Common;

namespace EDF.DL
{
    // Object used to store Filename and Path information of a single DWG file.
    public class Drawing : IDrawing
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string Path { get; set; }
        public string Group { get; set; }
    }

    // Helper enum to distinguish which data set is being worked with
    
}
