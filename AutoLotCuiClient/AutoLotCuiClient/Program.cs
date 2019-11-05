using System;
using System.Data;
using System.Configuration;
using AutoLotDal.ConnectedLayer;
using AutoLotDal.Models;

namespace AutoLotCuiClient
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** The AutoLot Console UI *****\n");

            var connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ToString();
            var userDone = false;

            var inventoryDal = new InventoryDal();
            inventoryDal.OpenConnection(connectionString);

            try
            {
                ShowInstructions();
                do
                {
                    Console.Write("\nPlease enter your command: ");

                    var userCommand = Console.ReadLine();
                    Console.WriteLine();

                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewCar(inventoryDal);
                            break;
                        case "U":
                            UpdateCarPetName(inventoryDal);
                            break;
                        case "D":
                            DeleteCar(inventoryDal);
                            break;
                        case "L":
                            ListInventory(inventoryDal);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(inventoryDal);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            Console.WriteLine("Bad data! Try again");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                inventoryDal.CloseConnection();
            }
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts a new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: Lists current inventory.");
            Console.WriteLine("S: Shows these instructions.");
            Console.WriteLine("P: Looks up pet name.");
            Console.WriteLine("Q: Quits program.");
        }

        private static void ListInventory(InventoryDal inventory)
        {
            var dt = inventory.GetAllInventoryAsDataTable();
            DisplayTable(dt);
        }

        private static void DisplayTable(DataTable dt)
        {
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                Console.Write($"{dt.Columns[i].ColumnName}\t");
            }

            Console.WriteLine("\n---------------------------------");

            for (var j = 0; j < dt.Rows.Count; j++)
            {
                for (var k = 0; k < dt.Columns.Count; k++)
                {
                    Console.Write($"{dt.Rows[j][k]}\t");
                }

                Console.WriteLine();
            }
        }

        private static void ListInventoryViaList(InventoryDal inventory)
        {
            var record = inventory.GetAllInventoryAsList();
            Console.WriteLine("CarId:\tMake:\tColor:\tPetName:");
            foreach (var c in record)
            {
                Console.WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }

        private static void DeleteCar(InventoryDal inventory)
        {
            Console.Write("Enter Id of Car to delete: ");
            var id = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                inventory.DeleteCar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InsertNewCar(InventoryDal inventory)
        {
            Console.Write("Enter Car Id: ");
            var newCarId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter Car Color: ");
            var newCarColor = Console.ReadLine();
            Console.Write("Enter Car Make: ");
            var newCarMake = Console.ReadLine();
            Console.Write("Enter Pet Name: ");
            var newCarPetName = Console.ReadLine();

            var c = new NewCar
            {
                CarId = newCarId,
                Color = newCarColor,
                Make = newCarMake,
                PetName = newCarPetName
            };

            inventory.InsertAuto(c);
        }

        private static void UpdateCarPetName(InventoryDal inventory)
        {
            Console.Write("Enter Car ID: ");
            var carId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter New Pet Name: ");
            var newCarPetName = Console.ReadLine();

            inventory.UpdateCarPetName(carId, newCarPetName);
        }

        private static void LookUpPetName(InventoryDal inventory)
        {
            Console.Write("Enter Id of Car to look up: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"PetName of {id} is {inventory.LookUpPetName(id).TrimEnd()}.");
        }

    }
}
