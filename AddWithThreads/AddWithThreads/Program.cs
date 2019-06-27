using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreads
{
    internal class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            var ap = new AddParams(10, 10);
            var t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            Thread.Sleep(5);

            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");

            Console.ReadLine();
        }
        private static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);

                var ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                waitHandle.Set();
            }
        }
    }

    internal class AddParams
    {
        public int a, b;

        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }
}
