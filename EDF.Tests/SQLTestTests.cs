using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDF.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace EDF.DL.Tests
{
    [TestClass()]
    public class SQLTestTests
    {
        [TestMethod()]
        public void CreateDBTest()
        {
            SQLTest.CreateDB();
            SQLTest test = new SQLTest();
            var expected = System.Data.ConnectionState.Open;

            test.ConnectDB();

            Assert.AreEqual(expected, test.Connection.State);
        }
    }
}