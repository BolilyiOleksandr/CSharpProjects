using CarDelegateMethodGroupConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Method Group Conversion *****\n");

            var c1 = new Car();
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(CallMeHere));

            Console.WriteLine("***** Speeding up *****:");
            for (var i = 0; i < 6; i++)
                c1.Accelerate(20);

            c1.UnRegisterWithCarEngine(CallMeHere);

            for (var i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        private static void CallMeHere(string msg)
        {
            Console.WriteLine("=> Message from Car: {0}", msg);
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("*****************************************************\n");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}
