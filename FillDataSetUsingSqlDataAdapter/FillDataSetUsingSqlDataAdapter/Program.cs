using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

namespace FillDataSetUsingSqlDataAdapter
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Adapters *****\n");

            const string connectionString = @"Data Source=SEGOTW10393726;Initial Catalog=AutoLot;Integrated Security=SSPI";
            var dataSet = new DataSet("AutoLot");
            var adapter = new SqlDataAdapter("SELECT * FROM Inventory", connectionString);
            var tableMapping = adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");
            adapter.Fill(dataSet, "Inventory");
            PrintDataSet(dataSet);

            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine($"DataSet is named: {ds.DataSetName}");
            foreach (DictionaryEntry entry in ds.ExtendedProperties)
            {
                Console.WriteLine($"Key = {entry.Key}, Value = {entry.Value}");
            }

            Console.WriteLine();

            foreach (DataTable table in ds.Tables)
            {
                Console.WriteLine($"=> {table.TableName} Table:");
                for (var column = 0; column < table.Columns.Count; column++)
                {
                    Console.Write(table.Columns[column].ColumnName + "\t");
                }

                Console.WriteLine("\n----------------------------------");

                for (var row = 0; row < table.Rows.Count; row++)
                {
                    for (var column = 0; column < table.Columns.Count; column++)
                    {
                        Console.Write(table.Rows[row][column].ToString().Trim() + "\t");
                    }

                    Console.WriteLine();
                }
            }
        }

    }
}
