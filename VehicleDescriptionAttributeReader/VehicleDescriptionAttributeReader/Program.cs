using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectOnAttributesUsingEarlyBinding();

            Console.ReadLine();
        }

        private static void ReflectOnAttributesUsingEarlyBinding()
        {
            var t = typeof(Winnebago);
            var customAtts = t.GetCustomAttributes(false);

            foreach (VehicleDescriptionAttribute v in customAtts)
            {
                Console.WriteLine("-> {0}\n", v.Description);
            }
        }

    }

}
