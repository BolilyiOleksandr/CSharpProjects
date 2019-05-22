using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            var c1 = new Car("SlugBug", 100, 10);

            //c1.AboutToBlow += CarIsAlmostDoomed;
            //c1.AboutToBlow += CarAboutToBlow;

            //EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            //c1.Exploded += d;

            //Console.WriteLine("***** Speeding up *****");
            //for (var i = 0; i < 6; i++)
            //{
            //    c1.Accelerate(20);
            //}

            //c1.Exploded -= d;

            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };

            Console.WriteLine("\n***** Speeding up ****");
            for (var i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            if (sender is Car)
            {
                var c = (Car)sender;
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", e.msg);
        }

        public static void CarExploded(object sender, CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        }
    }
}
