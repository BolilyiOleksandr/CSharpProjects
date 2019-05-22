using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            var aboutToBlowCounter = 0;

            var c1 = new Car("SlugBug", 100, 10);
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Critical Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventArgs e) { Console.WriteLine(e.msg); };

            for (var i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.WriteLine("AboutToBlow event was fired {0} times", aboutToBlowCounter);

            Console.ReadLine();

        }
    }
}
