using EDF.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EDF.DL.Tests
{
    [TestClass()]
    public class SqliteDataAccessTests
    {
        [TestMethod()]
        public void LoadDrawingsTest()
        {
            var expected = new List<Drawing>(){new Drawing(){
                File = "1000.dwg",
                Path = @"C:\1000.dwg",
                Group = "OP"
                }
            };
            SqliteDataAccess.SaveDrawings(expected);

            var result = SqliteDataAccess.LoadDrawings();

            Assert.AreEqual(expected[0].File, result[0].File);
            Assert.AreEqual(expected[0].Path, result[0].Path);
            Assert.AreEqual(expected[0].Group, result[0].Group);

        }

        [TestMethod()]
        public void LoadConnectionStringTest()
        {
            var expected = @"Data Source=.\DrawingDatabase.db;Version=3;";

            var result = SqliteDataAccess.LoadConnectionString();

            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void SaveDrawingTest()
        {
            var expected = new Drawing()
            {
                File = "1001.dwg",
                Path = @"C:\1001.dwg",
                Group = "OP"
            };

            SqliteDataAccess.SaveDrawing(expected);
            var result = SqliteDataAccess.LoadDrawing("1001.dwg");

            Assert.AreEqual(expected.File, result.File);
            Assert.AreEqual(expected.Path, result.Path);
            Assert.AreEqual(expected.Group, result.Group);

        }
    }
}