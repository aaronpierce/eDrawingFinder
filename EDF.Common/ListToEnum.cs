using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.Common
{
    public class ListToEnum
    {
        public static IEnumerator<IDrawing> Convert(List<IDrawing> list)
        {
            foreach (IDrawing item in list) { yield return item; }
        }
    }
}
