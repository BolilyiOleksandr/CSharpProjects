using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("****** Extending Interface Compatible Types *****\n");
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!" };
            data.PrintDataAndBeep();

            Console.WriteLine();
            var myInts = new List<int> { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }
}
