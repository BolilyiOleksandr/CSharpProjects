using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");

            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            var result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            var sum = funcTarget2(90, 300);
            Console.WriteLine(sum);

            Console.ReadLine();
        }

        private static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            var previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (var i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = previous;
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

    }
}
