using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Structures *****\n");

            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            myPoint.Increment();
            myPoint.Display();
            Console.ReadLine();

            Console.WriteLine();
        }
    }

    struct Point
    {
        public int X;
        public int Y;

        public void Increment()
        {
            X++;
            Y++;
        }

        public void Decrement()
        {
            X--;
            Y--;
        }

        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
}
