using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");
            Console.WriteLine("Main thread started. ThreadID = {0}", Thread.CurrentThread.ManagedThreadId);
            var p = new Printer();
            var workItem = new WaitCallback(PrintTheNumber);

            for (var i = 0; i < 10; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All tasks queued");

            Console.ReadLine();
        }

        public static void PrintTheNumber(object state)
        {
            var task = (Printer)state;
            task.PrintNumbers();
        }
    }

    internal class Printer
    {
        public void PrintNumbers() { }
    }
}
