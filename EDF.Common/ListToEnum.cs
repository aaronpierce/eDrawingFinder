using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.Common
{
    public class ListToEnum
    {
        public static IEnumerator<string> Convert(List<string> list)
        {
            foreach (string item in list) { yield return item; }
        }
    }
}
