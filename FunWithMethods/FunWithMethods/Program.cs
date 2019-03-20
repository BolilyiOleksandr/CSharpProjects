using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****\n");

            const int x = 9, y = 10;
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);
            Console.WriteLine();

            int ans;
            Add(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);
            Console.WriteLine();

            int i;
            string str;
            bool b;
            FillTheseValues(out i, out str, out b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            Console.WriteLine();

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0}, {1}", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0}, {1}", str1, str2);
            Console.WriteLine();

            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Avarage of data is: {0}", average);
            Console.WriteLine("Average of data is: {0}", CalculateAverage());
            Console.WriteLine();

            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.WriteLine();

            DisplayFancyMessage(message: "Wow! Very Fancy indeed!", textColor: ConsoleColor.DarkRed, backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, message: "Testing...", textColor: ConsoleColor.DarkBlue);
            DisplayFancyMessage(ConsoleColor.Blue, message: "Testing...", backgroundColor: ConsoleColor.White);
            Console.WriteLine();

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            var ans = x + y;
            x = 10000;
            y = 88888;
            return ans;
        }

        private static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        private static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        //private static void ThisWontCompile(out int a)
        //{
        //    Console.WriteLine("Error! Forgot to assign output arg!");
        //}

        private static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        private static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            return (sum / values.Length);
        }

        private static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        private static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
    }
}
