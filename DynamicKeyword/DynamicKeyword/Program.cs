using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //UseObjectVariable();
            //PrintThreeStrings();
            //ChangeDynamicDataType();
            //InvokeMembersOnDynamicData();

            VeryDynamicClass c = new VeryDynamicClass();
            c.DynamicMethod("1");

            Console.ReadLine();
        }

        private static void ImplicitlyTypedVariable()
        {
            var a = new List<int>();
            a.Add(90);
        }

        private static void UseObjectVariable()
        {
            object o = new Person() { FirstName = "Mike", LastName = "Larson" };
            Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);
        }

        private static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }

        private static void ChangeDynamicDataType()
        {
            dynamic t = "Hello";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }

        private static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Hello";
            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
    }

    internal class VeryDynamicClass
    {
        private static dynamic MyDynamicField;
        public dynamic DynamicProperty { get; set; }

        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            dynamic dynamicLocalVar = "Local variable";
            var myInt = 10;
            if (dynamicParam is int)
            {
                return dynamicLocalVar;
            }
            else
            {
                return myInt;
            }
        }
    }

}
