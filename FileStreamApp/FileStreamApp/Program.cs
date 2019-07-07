using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStreamApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with FileStreams *****\n");
            using (var fStream = File.Open(@"C:\myMessage.dat", FileMode.Create)) 
            {
                var message = "Hello!";
                var msgAsByteArray = Encoding.Default.GetBytes(message);
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                fStream.Position = 0;

                Console.Write("Your message as an array of bytes: ");
                var bytesFromFile = new byte[msgAsByteArray.Length];
                for (var i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte) fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }

                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }

            Console.ReadLine();
        }
    }
}
