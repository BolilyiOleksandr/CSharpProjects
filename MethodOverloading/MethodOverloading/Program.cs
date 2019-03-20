using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Method Overloading *****\n");

            Console.WriteLine(Add(10, 10));
            Console.WriteLine(Add(900000000000, 900000000000));
            Console.WriteLine(Add(4.3, 4.4));

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static double Add(double x, double y)
        {
            return x + y;
        }

        private static long Add(long x, long y)
        {
            return x + y;
        }
    }
}
