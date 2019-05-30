using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTypeViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            var typeName = "";
            do
            {
                Console.WriteLine("\nEnter a type name to efaluate");
                Console.WriteLine("or enter Q to quit:");
                typeName = Console.ReadLine();
                if (typeName.ToUpper() == "Q")
                    break;

                try
                {
                    var type = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(type);
                    ListFields(type);
                    ListProps(type);
                    ListMethods(type);
                    ListInterfaces(type);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, can't find type");
                }
            } while (true);
        }

        private static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            var methodNames = from n in t.GetMethods() select n;
            foreach (var name in methodNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        private static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
                Console.WriteLine("-> {0}", name);
            Console.WriteLine();
        }

        private static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine("-> {0}", name);
            Console.WriteLine();
        }

        private static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("-> {0}", i);
            Console.WriteLine();
        }

        private static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }

    }
}
