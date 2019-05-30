using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding *****");
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (a != null)
            {
                CreateUsingLateBinding(a);
                InvokeMethodWithArgsUsingLateBinding(a);
            }

            Console.ReadLine();
        }

        private static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                var miniVan = asm.GetType("CarLibrary.MiniVan");
                object obj = Activator.CreateInstance(miniVan);
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                mi.Invoke(obj, null);
                Console.WriteLine("Create a {0} using late binding!", obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // First, get a metadata description of the sports car.
                Type sport = asm.GetType("CarLibrary.SportsCar");
                // Now, create the sports car.
                object obj = Activator.CreateInstance(sport);
                // Invoke TurnOnRadio() with arguments.
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
