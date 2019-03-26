using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SQLite;
using Dapper;

namespace EDF.DL
{
    public class SqliteDataAccess
    {
        public static List<Drawing> LoadDrawings()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var output = con.Query<Drawing>("select * from Drawings", new DynamicParameters());
                return output.ToList();
            }
        }

        public static Drawing LoadDrawing(string File)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var output = con.Query<Drawing>($"select * from Drawings where File like '{File}'", new DynamicParameters());
                return output.ToList()[0];
            }
        }

        public static void SaveDrawing(Drawing drawing)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                string insert = @"INSERT INTO Drawings([File], [Path], [Group]) values (@File, @Path, @Group)";
                con.Execute(insert, drawing);
            }
        }

        public static void SaveDrawings(List<Drawing> drawings)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                string insert = @"INSERT INTO Drawings([File], [Path], [Group]) values (@File, @Path, @Group)";
                foreach (Drawing drawing in drawings)
                {
                    con.Execute(insert, drawing);
                }
            }
        }

        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
