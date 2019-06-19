using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LateBindingWithDynamic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AddWithReflection();
            AddWithDynamic();

            Console.ReadLine();
        }

        private static void AddWithReflection()
        {
            var asm = Assembly.Load("MathLibrary");
            try
            {
                var math = asm.GetType("MathLibrary.SimpleMath");
                var obj = Activator.CreateInstance(math);
                var mi = math.GetMethod("Add");
                object[] args = {10, 70};
                Console.WriteLine("Result is: {0}", mi.Invoke(obj, args));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddWithDynamic()
        {
            var asm = Assembly.Load("MathLibrary");
            try
            {
                var math = asm.GetType("MathLibrary.SimpleMath");
                dynamic obj = Activator.CreateInstance(math);
                Console.WriteLine("Result is: {0}", obj.Add(10, 70));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
