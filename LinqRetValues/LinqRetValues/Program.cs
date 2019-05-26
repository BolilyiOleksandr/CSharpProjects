using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Return Values *****\n");
            var subset = GetStringSubset();

            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }

            foreach (var item in GetStringSubsetArray())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var theRedColors = from c in colors where c.Contains("Red") select c;
            return theRedColors;
        }

        private static string[] GetStringSubsetArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var theRedColors = from c in colors where c.Contains("Red") select c;
            return theRedColors.ToArray();
        }

    }
}
