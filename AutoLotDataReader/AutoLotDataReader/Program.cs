using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");

            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLot",
                DataSource = @"SEGOTW10393726",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();

                ShowConnectionStatus(connection);

                const string sql = "SELECT * FROM Inventory";
                var myCommand = new SqlCommand(sql, connection);

                using (var myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        Console.WriteLine("***** Record *****");
                        for (var i = 0; i < myDataReader.FieldCount; i++)
                        {
                            Console.WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                        }

                        Console.WriteLine();
                    }
                }
            }

            Console.ReadLine();
        }

        private static void ShowConnectionStatus(SqlConnection connection)
        {
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine($"Database location: {connection.DataSource}");
            Console.WriteLine($"Database name: {connection.Database}");
            Console.WriteLine($"Timeout: {connection.ConnectionTimeout}");
            Console.WriteLine($"Connection state: {connection.State}\n");
        }
    }
}
