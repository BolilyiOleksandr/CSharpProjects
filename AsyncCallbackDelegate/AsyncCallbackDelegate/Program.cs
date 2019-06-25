using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        private static bool isDone = false;
        private static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            var b = new BinaryOp(Add);
            var iftAr = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working...");
            }

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoke on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        private static void AddComplete(IAsyncResult itfAr)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");

            var ar = (AsyncResult)itfAr;
            var b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(itfAr));

            var msg = (string) itfAr.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
