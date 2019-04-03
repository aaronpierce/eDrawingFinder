using EDF.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                File = "1142.dwg",
                Path = @"\\pokydata1\CAD\DWG\OP1\1142.dwg",
                Group = "OP"
                }
            };

            var result = SqliteDataAccess.LoadDrawings("1142.dwg", true.ToString(), "OP");

            Assert.AreEqual(expected[0].File, result[0].File);
            Assert.AreEqual(expected[0].Path, result[0].Path);
            Assert.AreEqual(expected[0].Group, result[0].Group);

        }

        [TestMethod()]
        public void LoadConnectionStringTest()
        {
            var database = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\eDrawingFinder\DrawingDatabase.db");
            var expected = $@"Data Source={database};Version=3;";

            var result = SqliteDataAccess.LoadConnectionString();

            Assert.AreEqual(result, expected);
        }
    }
}