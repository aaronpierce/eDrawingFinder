using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDF.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.DL.Tests
{
    [TestClass()]
    public class DataTests
    {
        [TestMethod()]
        public void GetEDrawingsInstallationsTest()
        {
            string expected = @"C:\Program Files\SOLIDWORKS Corp\eDrawings\eDrawings.exe";

            string actual = Data.GetMostRecentEDrawingInstall();

            Assert.AreEqual(expected, actual);
        }
    }
}