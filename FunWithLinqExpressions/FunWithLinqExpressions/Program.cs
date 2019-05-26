using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");

            var itemsInStock = new[]
            {
                new ProductInfo{Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo{Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo{Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo{Name = "Cruchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo{Name = "RipOff Water", Description = "From the tap of your wallet", NumberInStock = 100},
                new ProductInfo{Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
            };

            SelectEverything(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescription(itemsInStock);

            var objs = GetProjectedSubset(itemsInStock);
            foreach (var o in objs)
            {
                Console.WriteLine(o);
            }

            ReverseEverything(itemsInStock);
            AlphabetizeProductNames(itemsInStock);
            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcat();
            DisplayConcatDups();
            AggregateOps();

            Console.ReadLine();
        }

        private static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;
            foreach (var n in names)
                Console.WriteLine("Name: {0}", n);
        }

        private static void GetOverstock(ProductInfo[] products)
        {
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (var c in overstock)
                Console.WriteLine(c.ToString());
        }

        private static void GetNamesAndDescription(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
                Console.WriteLine(item.ToString());
        }

        private static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            return nameDesc.ToArray();
        }

        private static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
                Console.WriteLine(prod.ToString());
        }

        private static void AlphabetizeProductNames(ProductInfo[] products)
        {
            var subset = from p in products orderby p.Name ascending select p;
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
                Console.WriteLine(p.ToString());
        }

        private static void DisplayDiff()
        {
            var myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            var yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (var s in carDiff)
                Console.WriteLine(s);
        }

        private static void DisplayIntersection()
        {
            var myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            var yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
            Console.WriteLine("\nHere is what we have in common:");
            foreach (var s in carIntersect)
                Console.WriteLine(s);
        }

        private static void DisplayUnion()
        {
            var myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            var yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            Console.WriteLine("\nHere is everything:");
            foreach (var s in carUnion)
                Console.WriteLine(s);
        }

        private static void DisplayConcat()
        {
            var myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            var yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            Console.WriteLine("\r\n");
            foreach (var s in carConcat)
                Console.WriteLine(s);
        }

        private static void DisplayConcatDups()
        {
            var myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            var yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            Console.WriteLine("\r\n");
            foreach (var s in carConcat.Distinct())
                Console.WriteLine(s);
        }

        private static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            Console.WriteLine("\nMax temp: {0}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }

    }
}
