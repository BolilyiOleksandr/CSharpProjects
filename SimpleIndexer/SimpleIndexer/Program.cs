using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            //var myPeople = new PersonCollection();

            //myPeople[0] = new Person("Homer", "Simpson", 40);
            //myPeople[1] = new Person("Marge", "Simpson", 38);
            //myPeople[2] = new Person("Lisa", "Simpson", 9);
            //myPeople[3] = new Person("Bart", "Simpson", 7);
            //myPeople[4] = new Person("Maggie", "Simpson", 2);

            //for (var i = 0; i < myPeople.Count; i++)
            //{
            //    Console.WriteLine("Person number: {0}", i);
            //    Console.WriteLine("Name: {0} {1}", myPeople[i].Name, myPeople[i].Surname);
            //    Console.WriteLine("Age: {0}", myPeople[i].Age);
            //    Console.WriteLine();
            //}

            UseGenericListOfPeople();

            Console.ReadLine();

        }

        private static void UseGenericListOfPeople()
        {
            var myPeople = new List<Person>();
            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            myPeople[0] = new Person("Maggie", "Simpson", 2);

            for (var i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].Name, myPeople[i].Surname);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }

    }
}
