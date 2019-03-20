using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");

            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Console.WriteLine("\n***** Fun with Class Types *****");

            //Car chuck = new Car();
            //chuck.PrintState();

            //Car mary = new Car("Mary");
            //mary.PrintState();

            //Car daisy = new Car("Daisy", 75);
            //daisy.PrintState();

            //Motorcycle mc = new Motorcycle();
            //mc.PopAWheely();

            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny");
            c.PopAWheely();
            Console.WriteLine("Rider name is {0}", c.driverName);

            Motorcycle m1 = new Motorcycle();
            Console.WriteLine("Name = {0}, Intensity = {1}", m1.driverName, m1.driverIntensity);

            Motorcycle m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name = {0}, Intensity = {1}", m2.driverName, m2.driverIntensity);

            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine("Name = {0}, Intensity = {1}", m3.driverName, m3.driverIntensity);

            Console.ReadLine();
        }
    }

    internal class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        //public Motorcycle()
        //{
        //    Console.WriteLine("In default ctor");
        //}
        //public Motorcycle(int intensity) : this(intensity, "")
        //{
        //    Console.WriteLine("In ctor taking an int");
        //}
        //public Motorcycle(string name) : this(0, name)
        //{
        //    Console.WriteLine("In ctor taking a string");
        //}
        //public Motorcycle(int intensity, string name)
        //{
        //    if (intensity > 10)
        //    {
        //        intensity = 10;
        //    }
        //    driverIntensity = intensity;
        //    driverName = name;
        //    Console.WriteLine("In ctor taking an int and a string");
        //}

        public Motorcycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }

        public void SetDriverName(string name)
        {
            driverName = name;
        }
        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaeeewww!");
            }
        }

        private static void MakeSomeBicycles()
        {
            var m1 = new Motorcycle();
            Console.WriteLine("Name = {0}, Intensity = {1}", m1.driverName, m1.driverIntensity);

            var m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name = {0}, Intensity = {1}", m2.driverName, m2.driverIntensity);

            var m3 = new Motorcycle(7);
            Console.WriteLine("Name = {0}, Intensity = {1}", m3.driverName, m3.driverIntensity);
        }
    }
}
