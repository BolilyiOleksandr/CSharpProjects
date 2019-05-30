using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            var asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");

                asmName = Console.ReadLine();
                if (asmName.ToUpper() == "Q")
                {
                    break;
                }

                try
                {
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, can't find assemby");
                }
            } while (true);
        }

        private static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("-> {0}", asm.FullName);
            var types = asm.GetTypes();
            foreach (var t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }
    }
}
