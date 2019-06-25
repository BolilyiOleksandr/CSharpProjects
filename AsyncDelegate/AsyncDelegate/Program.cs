using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            var b = new BinaryOp(Add);
            IAsyncResult iftAr = b.BeginInvoke(10, 10, null, null);

            while (!iftAr.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }

            var answer = b.EndInvoke(iftAr);
            Console.WriteLine("10 + 10 is {0}", answer);

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            return x + y;
        }

    }
}
