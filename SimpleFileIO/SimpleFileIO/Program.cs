using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleFileIO
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox One" };
            File.WriteAllLines(@"C:\tasks.txt", myTasks);
            foreach (string task in File.ReadAllLines(@"C:\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }
        }
    }
}
