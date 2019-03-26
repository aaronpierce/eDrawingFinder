using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.Common
{
    public interface IDrawing
    {
        int Id { get; set; }
        string File { get; set; }
        string Path { get; set; }
        string Group { get; set; }
    }
}
