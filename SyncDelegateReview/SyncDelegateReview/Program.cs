using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            var b = new BinaryOp(Add);
            var answer = b(10, 10);

            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
