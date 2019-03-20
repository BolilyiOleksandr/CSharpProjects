using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Automatic Properties *****\n");

            var c = new Car()
            {
                PetName = "Frank",
                Speed = 55,
                Color = "Red"
            };

            Console.WriteLine("Your car is named {0}? That't odd...", c.PetName);
            c.DisplayStats();

            var g = new Garage()
            {
                MyAuto = c
            };
            Console.WriteLine("Number of Cars: {0}", g.NumberOfCars);
            Console.WriteLine("Your car is named: {0}", g.MyAuto.PetName);

            Console.ReadLine();
        }
    }

    internal class Car
    {
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        private readonly int _numberOfDoors = 2;

        public void DisplayStats()
        {
            Console.WriteLine("Car Name: {0}", PetName);
            Console.WriteLine("Speed :{0}", Speed);
            Console.WriteLine("Color: {0}", Color);
        }
    }

    internal class Garage
    {
        public int NumberOfCars { get; set; } = 1;
        public Car MyAuto { get; set; } = new Car();

        public Garage() { }

        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
