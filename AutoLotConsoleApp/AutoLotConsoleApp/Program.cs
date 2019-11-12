using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;

namespace AutoLotConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with ADO.NET EF *****\n");

            var carId = AddNewRecord();
            UpdateRecord(carId);
            // RemoveRecordUsingEntityState(carId);
            // RemoveRecord(carId);
            // Console.WriteLine(carId);
            // PrintAllInventory();
            // FunWithLinqQueries();

            Console.ReadLine();
        }

        private static int AddNewRecord()
        {
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Car()
                    {
                        Make = "Yugo",
                        Color = "Brown",
                        CarNickName = "Brownie"
                    };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                //foreach (var c in context.Cars)
                //{
                //    Console.WriteLine(c);
                //}

                //foreach (var c in context.Cars.SqlQuery(
                //    "SELECT CarId, Make, Color, PetName as CarNickName FROM Inventory where Make=@p0", "BMW"))
                //{
                //    Console.WriteLine(c);
                //}

                foreach (var c in context.Cars.Where(c => c.Make == "BMW"))
                {
                    Console.WriteLine(c);
                }
            }
        }

        private static void FunWithLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                var allData = context.Cars.ToArray();
                var colorsMake = from item in allData
                                 select new
                                 {
                                     item.Color,
                                     item.Make
                                 };
                foreach (var item in colorsMake)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                var blackCars = from item in allData where item.Color == "Black" select item;
                foreach (var item in blackCars)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void RemoveRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                var carToDelete = context.Cars.Find(carId);
                if (carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    context.SaveChanges();
                }
            }
        }

        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                var carToDelete = new Car() { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                var carToUpdate = context.Cars.Find(carId);
                if (carToUpdate != null)
                {
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }

    }
}
