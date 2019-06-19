using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VehicleAttributeReaderLateBinding
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectAttributesUsingLateBinding();

            Console.ReadLine();
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                var asm = Assembly.Load("AttributedCarLibrary");
                var vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
                var propDesc = vehicleDesc.GetProperty("Description");
                var types = asm.GetTypes();

                foreach (var t in types)
                {
                    var objs = t.GetCustomAttributes(vehicleDesc, false);

                    foreach (var o in objs)
                    {
                        Console.WriteLine("-> {0}: {1}\n", t.Name, propDesc?.GetValue(o, null));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}
