using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace MultiThreadedPrinting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Synchronizing Threads *****\n");
            var p = new Printer();
            var threads = new Thread[10];
            for (var i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }

            Console.ReadLine();
        }
    }

    [Synchronization]
    public class Printer : ContextBoundObject
    {
        //public void PrintNumbers()
        //{
        //    var threadLock = new object();
        //    lock (threadLock)
        //    {
        //        for (var i = 0; i < 10; i++)
        //        {
        //            var r = new Random();
        //            Thread.Sleep(1000 * r.Next(5));
        //            Console.Write("{0}, ", i);
        //        }

        //        Console.WriteLine();
        //    }
        //}

        public void PrintNumbers()
        {
            var threadLock = new object();
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);
                Console.Write("Your numbers: ");
                for (var i = 0; i < 10; i++)
                {
                    var r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }

                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }

    }
}
