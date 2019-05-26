using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = from game in currentVideoGames where game.Contains(" ") orderby game ascending select game;
            foreach (var s in subset)
                Console.WriteLine("Item: {0}", s);

            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithEnumerableAndLambdas2();
            QueryStringsWithAnonymousMethods();

            Console.ReadLine();
        }

        private static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine();
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }

        private static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions * ****");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Break it down!
            var gamesWithSpaces = currentVideoGames.Where(game =>
                game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game =>
                game);
            var subset = orderedGames.Select(game => game);
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);

        }

        private static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("\n***** Using Anonymous Methods *****");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            Func<string, bool> searchFilter = delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }

    }
}
