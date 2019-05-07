using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseGenericList();
            UseSortedSet();
        }

        //static void UseGenericList()
        //{
        //    List<Person> people = new List<Person>()
        //    {
        //        new Person{FirstName = "Homer", LastName = "Simpson", Age = 47},
        //        new Person{FirstName = "Marge", LastName = "Simpson", Age = 45},
        //        new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9},
        //        new Person{FirstName = "Bart", LastName = "Simpson", Age = 8}
        //    };

        //    Console.WriteLine("Items in list: {0}", people.Count);

        //    foreach (Person p in people)
        //        Console.WriteLine(p);

        //    Console.WriteLine("\n->Inserting new person.");
        //    people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
        //    Console.WriteLine("Items in list: {0}", people.Count);

        //    Person[] arrayOfPeople = people.ToArray();
        //    for (int i = 0; i < arrayOfPeople.Length; i++)
        //    {
        //        Console.WriteLine("First Name: {0}", arrayOfPeople[i].FirstName);
        //    }

        //    Console.ReadLine();
        //}

        //static void UseGenericList()
        //{
        //    Stack<Person> stackOfPeople = new Stack<Person>();
        //    stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
        //    stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
        //    stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

        //    Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
        //    Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
        //    Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
        //    Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
        //    Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
        //    Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

        //    try
        //    {
        //        Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
        //        Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        Console.WriteLine("\nError! {0}", ex.Message);
        //    }

        //    Console.ReadLine();
        //}

        static void UseGenericList()
        {
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            Console.WriteLine("{0} is first at line!", peopleQ.Peek().FirstName);

            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error! {0}", ex.Message);
            }

            Console.ReadLine();
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }

        static void UseSortedSet()
        {
            SortedSet<Person> setOfPerson = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person{FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person{FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person{FirstName = "Bart", LastName = "Simpson", Age = 8}
            };

            foreach (Person p in setOfPerson)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            setOfPerson.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPerson.Add(new Person {FirstName = "Mikko", LastName = "Jones", Age = 32});

            foreach (Person p in setOfPerson)
            {
                Console.WriteLine(p);
            }

        }

    }

    class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.Age > secondPerson.Age)
                return 1;
            if (firstPerson.Age < secondPerson.Age)
                return -1;
            else
                return 0;
        }
    }

}
