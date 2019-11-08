using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDal.DataSets;
using AutoLotDal.DataSets.AutoLotDataSetTableAdapters;

namespace LinqToDataSetApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over DataSet ***** \n");

            var dal = new AutoLotDataSet();
            var tableAdapter = new InventoryTableAdapter();
            var data = tableAdapter.GetData();
            PrintAllCarIds(data);
            ShowRedCars(data);

            Console.ReadLine();
        }

        private static void PrintAllCarIds(DataTable data)
        {
            var enumData = data.AsEnumerable();
            foreach (var r in enumData)
            {
                Console.WriteLine($"Car Id = {r["CarId"]}");
            }
        }

        private static void ShowRedCars(DataTable data)
        {
            Console.WriteLine();
            var cars = from car in data.AsEnumerable()
                       where
                           car.Field<string>("Color") == "Red"
                       select new
                       {
                           Id = car.Field<int>("CarId"),
                           Make = car.Field<string>("Make")
                       };
            Console.WriteLine("Here are the red cars we have in stock");
            foreach (var item in cars)
            {
                Console.WriteLine($"-> CarId = {item.Id} is {item.Make}");
            }
        }

    }
}
