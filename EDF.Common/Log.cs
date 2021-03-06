﻿using System;

namespace EDF.Common
{
    // Logging class to write to console/file for troubleshotting and debugging.
    public class Log
    {
        public static readonly log4net.ILog Write = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }

    public static class Test
    {
        public static void Tester()
        {
            Console.WriteLine("Test");
            Log.Write.Info("Test-Log");
        }
    }
}
