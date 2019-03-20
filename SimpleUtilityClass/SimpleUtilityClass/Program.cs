using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;

namespace SimpleUtilityClass
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Classes *****\n");
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            Console.ReadLine();
        }
    }

    internal static class TimeUtilClass
    {
        public static void PrintTime()
        {
            WriteLine(Now.ToShortTimeString());
        }

        public static void PrintDate()
        {
            WriteLine(Today.ToShortDateString());
        }
    }
}
