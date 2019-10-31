using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;

namespace MyConnectionFactory
{
    internal enum DataProvider
    {
        SqlServer,
        OleDb,
        Odbc,
        None
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Very Simple Connection Factory *****\n");

            var dataProviderString = ConfigurationManager.AppSettings["provider"];
            var dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                Console.WriteLine("Sorry, no provider exists!");
                Console.ReadLine();
                return;
            }

            var myConnection = GetConnection(dataProvider);
            Console.WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");

            Console.ReadLine();
        }

        private static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.None:
                    break;
                default:
                    break;
            }

            return connection;
        }
    }
}
