using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();

            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
            {
                Console.WriteLine("Value of 'i' is: {0}", i.Value);
            }
            else
            {
                Console.WriteLine("Value of 'i' is undefined.");
            }

            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
            {
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            }
            else
            {
                Console.WriteLine("Value of 'b' is undefined.");
            }

            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            TesterMethod(null);

            Console.ReadLine();
        }

        private static void LocalNullableVariables()
        {
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];

        }

        private static void LocalNullableVariablesUsingNullable()
        {
            Nullable<int> nullableInt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }

        private static void TesterMethod(string[] args)
        {
                Console.WriteLine($"You send me {args?.Length ?? 0} arguments.");
        }
    }

    internal class DatabaseReader
    {
        public int? numericValue = null;
        public bool? boolValue = true;

        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }

}
