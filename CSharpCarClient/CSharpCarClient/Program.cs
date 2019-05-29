using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace CSharpCarClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** C# CarLibrary Client App *****");
            var viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();

            var mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Done. Press any key to terminate");

            Console.ReadLine();
        }
    }
}
