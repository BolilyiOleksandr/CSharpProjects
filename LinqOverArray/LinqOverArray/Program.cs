using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            QueryOverStringsLongHand();
            QueryOverInts();

            Console.ReadLine();
        }

        private static void QueryOverStrings()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            foreach (var s in subset)
                Console.WriteLine("Item: {0}", s);

            ReflectOverQueryResults(subset);
        }

        private static void QueryOverStringsLongHand()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var gamesWithSpace = new string[5];
            for (var i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpace[i] = currentVideoGames[i];
            }

            Array.Sort(gamesWithSpace);
            foreach (var s in gamesWithSpace)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }

            Console.WriteLine();
        }

        private static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Info about your query *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet locations: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        private static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in numbers where i < 10 select i;

            foreach (var i in subset)
                Console.WriteLine("Item: {0}", i);
            Console.WriteLine();

            numbers[0] = 4;
            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);
            Console.WriteLine();

            ReflectOverQueryResults(subset);
        }

        private static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();
        }

    }

    internal class LinqBasedFieldAreClunky
    {
        private static string[] currentVideoGames =
            {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

        private IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;

        public void PrintGames()
        {
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
        }
    }

}
