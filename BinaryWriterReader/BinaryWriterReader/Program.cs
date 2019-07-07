using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryWriterReader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Binary Writers / Readers *****\n");

            var f = new FileInfo("BinFile.dat");
            using (var bw = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                var aDouble = 1234.67;
                var anInt = 34567;
                var aString = "A, B, C";

                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            Console.WriteLine("Done!");

            using (var br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.ReadLine();
        }
    }
}
