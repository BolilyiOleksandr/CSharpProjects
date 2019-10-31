﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

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
            var myConnection = GetConnection(DataProvider.SqlServer);
            Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");
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