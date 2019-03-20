using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Passing Person object by value *****");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nBefore by value call, Person is:");
            fred.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("After by value call, Person is:");
            fred.Display();

            Person mel = new Person("Mel", 23);
            Console.WriteLine("\nBefore by ref call, Person is:");
            mel.Display();

            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();

            Console.ReadLine();
        }

        private static void SendAPersonByValue(Person p)
        {
            p.personAge = 99;
            p = new Person("Nikki", 99);
        }

        private static void SendAPersonByReference(ref Person p)
        {
            p.personAge = 555;
            p = new Person("Nikki", 999);
        }
    }

    internal class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person() { }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    }
}
