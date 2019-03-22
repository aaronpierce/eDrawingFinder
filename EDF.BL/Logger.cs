using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace eDrawingFinder
{
    // Logging class to write to console/file for troubleshotting and debugging.
    class Log
    {
        public static readonly log4net.ILog Write = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
