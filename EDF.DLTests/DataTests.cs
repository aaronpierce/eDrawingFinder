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
            Data.GetEDrawingsInstallations();
            Assert.Fail();
        }
    }
}