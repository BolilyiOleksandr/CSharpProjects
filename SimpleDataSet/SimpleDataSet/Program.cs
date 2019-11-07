using System;
using System.Data;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleDataSet
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with DataSets *****\n");

            var carsInventoryDs = new DataSet("Car Inventory");
            carsInventoryDs.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDs.ExtendedProperties["DataSetId"] = Guid.NewGuid();
            carsInventoryDs.ExtendedProperties["Company"] = "Mikko's Hot Tub Super Store";

            FillDataSet(carsInventoryDs);
            PrintDataSet(carsInventoryDs);
            SaveAndLoadAsXml(carsInventoryDs);
            SaveAndLoadAsBinary(carsInventoryDs);

            Console.ReadLine();
        }

        private static void FillDataSet(DataSet dataSet)
        {
            var carIdColumn = new DataColumn("CarId", typeof(int))
            {
                Caption = "Car Id",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };
            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string))
            {
                Caption = "Pet Name"
            };
            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[] { carIdColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            var carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            carRow["Make"] = "Saab";
            carRow["Color"] = "Red";
            carRow["PetName"] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            inventoryTable.PrimaryKey = new[]
            {
                inventoryTable.Columns[0]
            };

            dataSet.Tables.Add(inventoryTable);
        }

        private static void PrintDataSet(DataSet dataSet)
        {
            Console.WriteLine($"DataSet is named: {dataSet.DataSetName}");
            foreach (DictionaryEntry entry in dataSet.ExtendedProperties)
            {
                Console.WriteLine($"Key = {entry.Key}, Value = {entry.Value}");
            }

            Console.WriteLine();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine($"=> {table.TableName} Table:");
                for (var column = 0; column < table.Columns.Count; column++)
                {
                    Console.Write($"{table.Columns[column].ColumnName}\t");
                }

                Console.WriteLine("\n-----------------------------------");

                PrintTable(table);
            }
        }

        private static void PrintTable(DataTable table)
        {
            var reader = table.CreateDataReader();
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetValue(i).ToString().Trim()}\t");
                }

                Console.WriteLine();
            }

            reader.Close();
        }

        private static void SaveAndLoadAsXml(DataSet cardInventoryDataSet)
        {
            cardInventoryDataSet.WriteXml("carsDataSet.xml");
            cardInventoryDataSet.WriteXmlSchema("carsDataSet.xsd");
            cardInventoryDataSet.Clear();
            cardInventoryDataSet.ReadXml("carsDataSet.xml");
        }

        private static void SaveAndLoadAsBinary(DataSet carsInventoryDs)
        {
            carsInventoryDs.RemotingFormat = SerializationFormat.Binary;
            var fileStream = new FileStream("BinaryCars.bin", FileMode.Create);
            var binaryFormat = new BinaryFormatter();
            binaryFormat.Serialize(fileStream, carsInventoryDs);
            fileStream.Close();

            carsInventoryDs.Clear();

            fileStream = new FileStream("BinaryCars.bin", FileMode.Open);
            var data = (DataSet)binaryFormat.Deserialize(fileStream);
        }

        public static void ManipulateDataRowState()
        {
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            var row = temp.NewRow();
            Console.WriteLine($"After calling NewRow(): {row.RowState}");

            temp.Rows.Add(row);
            Console.WriteLine($"After calling Rows.Add(): {row.RowState}");

            row["TempColumn"] = 10;
            Console.WriteLine($"After first assignment: {row.RowState}");

            temp.AcceptChanges();
            Console.WriteLine($"After calling AcceptChanges: {row.RowState}");

            row["TempColumn"] = 11;
            Console.WriteLine($"After first assignment: {row.RowState}");

            temp.Rows[0].Delete();
            Console.WriteLine($"After calling Delete: {row.RowState}");
        }

    }
}
