﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Exceptions *****\n");
            var myCar = new Car("Rusty", 90);

            try
            {
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }

            Console.ReadLine();
        }
    }
}
