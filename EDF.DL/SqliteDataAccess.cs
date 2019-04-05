using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Diagnostics;
using EDF.Common;

namespace EDF.DL
{
    public class SqliteDataAccess
    {
        //Dapper.SQLBuilder Query using template
        private static List<Drawing> QueryDatabase(SqlBuilder.Template template)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                return connection.Query<Drawing>(template.RawSql, template.Parameters).ToList();
            }
        }

        //Load all drawings from DB to list of Drawing objects
        public static List<Drawing> LoadAllDrawings()
        {
            SqlBuilder builder = new Dapper.SqlBuilder();
            SqlBuilder.Template select = builder.AddTemplate("SELECT * FROM Drawings");

            return QueryDatabase(select);
        }

        //Load from filter using Dapper.SQLBuilder to combine where clauses
        public static List<Drawing> LoadDrawings(string filter, string starts, string group)
        {
            SqlBuilder builder = new Dapper.SqlBuilder();
            SqlBuilder.Template select = builder.AddTemplate("SELECT * FROM Drawings /**where**/");

            if (!string.IsNullOrEmpty(filter))
                builder.Where($"\"File\" like '{starts}{filter}%'");
            if (!string.IsNullOrEmpty(group))
                builder.Where($"\"Group\" like '{group}'");

            Log.Write.Info(select.RawSql.TrimEnd());

            return QueryDatabase(select);
        }

        //Saves a single drawing from drawing object using Dapper. Probably never to be used.
        public static void SaveDrawing(Drawing drawing)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string insert = @"INSERT INTO Drawings([File], [Path], [Group]) values (@File, @Path, @Group)";
                connection.Execute(insert, drawing);
            }
        }

        //Takes a list of drawings objects (usually 199,000ish), builds Dapper SQL transaction and commits it. Takes 4ish seconds.
        public static void SaveDrawings(List<Drawing> drawings)
        {
            int totalAffectedRows = 0;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    foreach (Drawing drawing in drawings)
                    {
                        string insert = @"INSERT INTO Drawings([File], [Path], [Group]) values (@File, @Path, @Group)";
                        totalAffectedRows += connection.Execute(sql: insert, param: drawing, transaction: transaction);
                    }

                    transaction.Commit();
                    Log.Write.Info($"Database transaction took {stopwatch.Elapsed.TotalSeconds} seconds [{totalAffectedRows} affected rows]");
                }
            }
             
        }

        //Drops SQL table for when running background update on database
        public static void ClearTable()
        {
            Log.Write.Info("Dropping the 'Drawings' table");
            using (SQLiteConnection connection = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                connection.Open();

                string dropTable = "DROP TABLE \"Drawings\"";

                SQLiteCommand command = new SQLiteCommand(dropTable, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    Log.Write.Info("Drawing table did not exist so it was not dropped");
                }
            }
        }

        //Builds SQL table for use after clearing or creating a new Database.
        public static void BuildTable()
        {
            Log.Write.Info("Creating a new 'Drawings' table");

            using (SQLiteConnection connection = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                connection.Open();

                string createTable = "CREATE TABLE \"Drawings\"(\"Id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, \"File\" TEXT NOT NULL, \"Path\" TEXT NOT NULL, \"Group\" TEXT NOT NULL)";

                SQLiteCommand command = new SQLiteCommand(createTable, connection);
                command.ExecuteNonQuery();

            }
        }

        public static bool IsTableEmpty()
        {
            int result;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    result = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Drawings");
                }
                catch
                {
                    Log.Write.Info("Table doesn't exist");
                    return true;
                }
            }

            Log.Write.Info($"Drawings table has {result} at loading check");
            return (result > 0 ? false : true);
        }

        //Load connection string from EDF.UI app.config settings
        public static string LoadConnectionString(string id = "Default")
        {
            return Environment.ExpandEnvironmentVariables(ConfigurationManager.ConnectionStrings[id].ConnectionString);
        }

        //Returns full file path to database from connection string
        public static string LoadDatabaseName()
        {
            return LoadConnectionString().Split('=')[1].Split(';')[0];
        }
    }
}
