using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.DL
{
    public class SQLTest
    {
        public SQLiteConnection Connection { get; set; }
        public static void CreateDB()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        public void ConnectDB()
        {
            Connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            Connection.Open();
        }
    }
}
