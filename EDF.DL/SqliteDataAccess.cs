using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Diagnostics;

namespace EDF.DL
{
    public class SqliteDataAccess
    {
        public static List<Drawing> LoadDrawings()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<Drawing>("select * from Drawings", new DynamicParameters());
                return output.ToList();
            }
        }

        public static Drawing LoadDrawing(string File)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<Drawing>($"select * from Drawings where File like '{File}'", new DynamicParameters());
                return output.ToList()[0];
            }
        }

        public static void SaveDrawing(Drawing drawing)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string insert = @"INSERT INTO Drawings([File], [Path], [Group]) values (@File, @Path, @Group)";
                connection.Execute(insert, drawing);
            }
        }

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
                    Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds} seconds with one transaction. {totalAffectedRows} affected rows.");
                }
            }
             
        }

        public static string LoadConnectionString(string id = "Default")
        {
            return Environment.ExpandEnvironmentVariables(ConfigurationManager.ConnectionStrings[id].ConnectionString);
        }

        public static string LoadDatabaseName()
        {
            return LoadConnectionString().Split('=')[1].Split(';')[0];
        }
    }
}
