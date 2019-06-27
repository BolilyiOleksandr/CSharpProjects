using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            var timeCb = new TimerCallback(PrintTime);
            var t = new Timer(timeCb, "Hello from Main", 0, 1000);

            Console.WriteLine("Hit key to terminate...");

            Console.ReadLine();
        }

        private static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }
    }
}
