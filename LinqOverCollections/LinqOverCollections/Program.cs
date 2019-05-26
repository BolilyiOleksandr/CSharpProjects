using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            var myCars = new List<Car>()
            {
                new Car{PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            GetFastBmws(myCars);
            LinqOVerArrayList();
            OfTypeAsFilter();

            Console.ReadLine();
        }

        private static void GetFastCars(List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        private static void GetFastBmws(List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 90 && c.Make == "BMW" select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        private static void LinqOVerArrayList()
        {
            Console.WriteLine("***** LINQ Over ArrayList *****");
            var myCars = new ArrayList()
            {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            var myCarsEnum = myCars.OfType<Car>();
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
                Console.WriteLine("{0} is going too fast!", car.PetName);
        }

        private static void OfTypeAsFilter()
        {
            var myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();
            foreach (var i in myInts)
                Console.WriteLine("Int value: {0}", i);
        }

    }
}
