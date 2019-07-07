using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamWriterReaderApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

            using (var writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don's forget Father's Day this year...");
                writer.WriteLine("Don't forger these numbers:");
                for (var i = 0; i < 10; i++)
                    writer.Write(i + " ");
                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Created file and wrote some thoughts...");

            Console.WriteLine("Here are your thoughts:\n");
            using (var sr = File.OpenText("reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }

            Console.ReadLine();
        }
    }
}
