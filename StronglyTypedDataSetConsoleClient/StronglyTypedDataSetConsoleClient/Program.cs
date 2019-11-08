using System;
using System.Data;
using AutoLotDal.DataSets;
using AutoLotDal.DataSets.AutoLotDataSetTableAdapters;
using AutoLotDal.DisconnectedLayer;
using System.Linq;

namespace StronglyTypedDataSetConsoleClient
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strongly Typed DataSets *****\n");

            var table = new AutoLotDataSet.InventoryDataTable();
            var adapter = new InventoryTableAdapter();
            AddRecords(table, adapter);
            RemoveRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);
            CallStoredProc();
            PrintDataWithIndexers(table);
            PrintDataWithDataTableReader(table);
            AddRowWithTypedDataSet();

            Console.ReadLine();
        }

        private static void PrintInventory(AutoLotDataSet.InventoryDataTable dataTable)
        {
            for (var column = 0; column < dataTable.Columns.Count; column++)
            {
                Console.Write(dataTable.Columns[column].ColumnName + "\t");
            }

            Console.WriteLine("\n--------------------------------------");

            for (var row = 0; row < dataTable.Rows.Count; row++)
            {
                for (var column = 0; column < dataTable.Columns.Count; column++)
                {
                    Console.Write(dataTable.Rows[row][column] + "\t");
                }

                Console.WriteLine();
            }
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try
            {
                var newRow = table.NewInventoryRow();
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Saku";
                table.AddInventoryRow(newRow);
                table.AddInventoryRow("Yugo", "Green", "Zippy");
                adapter.Update(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try
            {
                var rowToDelete = table.FindByCarId(1);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
                rowToDelete = table.FindByCarId(2);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CallStoredProc()
        {
            Console.WriteLine();
            try
            {
                var queriesTableAdapter = new QueriesTableAdapter();
                Console.Write("Enter Id of car to look up: ");
                var carId = Console.ReadLine() ?? "0";
                var carName = "";
                queriesTableAdapter.GetPetName(int.Parse(carId), ref carName);
                Console.WriteLine($"CarId {carId} has the name of {carName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintDataWithIndexers(DataTable table)
        {
            Console.WriteLine();
            for (var row = 0; row < table.Rows.Count; row++)
            {
                for (var column = 0; column < table.Columns.Count; column++)
                {
                    Console.Write(table.Rows[row][column] + "\t");
                }

                Console.WriteLine();
            }
        }

        private static void PrintDataWithDataTableReader(DataTable table)
        {
            Console.WriteLine();
            var reader = table.CreateDataReader();
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetValue(i)}\t");
                }

                Console.WriteLine();
            }

            reader.Close();
        }

        private static void AddRowWithTypedDataSet()
        {
            var inventoryDataAdapter = new InventoryTableAdapter();
            var inventory = inventoryDataAdapter.GetData();
            inventory.AddInventoryRow("Ford", "Yellow", "Sal");
            inventoryDataAdapter.Update(inventory);
        }

        private static void LinqOverDataTable()
        {
            var dal = new InventoryDalDc(
                @"Data Source=SEGOTW10393726;Initial Catalog=AutoLot;Integrated Security=True");
            var data = dal.GetAllInventory();
            //var moreData = from c in data where (int)c["CarId"] > 5 select 5;
        }

    }
}
