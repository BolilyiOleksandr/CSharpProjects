﻿using System;
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
            AddAsync();

            Console.ReadLine();
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main: {0}", Thread.CurrentThread.ManagedThreadId);

            var ap = new AddParams(10, 10);
            await Sum(ap);

            Console.WriteLine("Other thread is done!");
        }

        private static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                if (data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);

                    var ap = (AddParams)data;
                    Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
                }
            });
        }
    }

    internal class AddParams
    {
        public int a, b;

        public AddParams(int intA, int intB)
        {
            a = intA;
            b = intB;
        }
    }

}
