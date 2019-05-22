using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();

            Console.ReadLine();
        }

        private static void TraditionalDelegateSyntax()
        {
            var list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            Predicate<int> callback = IsEvenNumber;
            var evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        private static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        private static void AnonymousMethodSyntax()
        {
            var list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            var evenNumbers = list.FindAll(delegate (int i) { return (i % 2) == 0; });

            Console.WriteLine("Here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        private static void LambdaExpressionSyntax()
        {
            var list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            var evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                var isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

    }
}
