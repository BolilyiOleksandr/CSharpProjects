using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Overloaded Operators *****\n");

            var ptOne = new Point(100, 100);
            var ptTwo = new Point(40, 40);
            Console.WriteLine("ptOne = {0}", ptOne);
            Console.WriteLine("ptTwo = {0}", ptTwo);

            Console.WriteLine("ptOne + ptTwo: {0}", ptOne + ptTwo);
            Console.WriteLine("ptOne - ptTwo: {0}", ptOne - ptTwo);

            var biggerPoint = ptOne + 10;
            Console.WriteLine("ptOne + 10 = {0}", biggerPoint);
            Console.WriteLine("10 + biggerPoint = {0}", 10 + biggerPoint);

            var ptThree = new Point(90, 5);
            Console.WriteLine("ptThree = {0}", ptThree);
            Console.WriteLine("ptThree += ptTwo: {0}", ptThree += ptTwo);

            var ptFour = new Point(0, 500);
            Console.WriteLine("ptFour: {0}", ptFour);
            Console.WriteLine("ptFour -= ptThree: {0}", ptFour -= ptThree);

            var ptFive = new Point(1, 1);
            Console.WriteLine("++ptFive = {0}", ++ptFive);
            Console.WriteLine("--ptFive = {0}", --ptFive);

            var ptSix = new Point(20, 20);
            Console.WriteLine("ptSix++ = {0}", ptSix++);
            Console.WriteLine("ptSix-- = {0}", ptSix--);

            Console.WriteLine("ptOne == ptTwo : {0}", ptOne == ptTwo);
            Console.WriteLine("ptOne != ptTwo : {0}", ptOne != ptTwo);

            Console.WriteLine("ptOne < ptTwo : {0}", ptOne < ptTwo);
            Console.WriteLine("ptOne > ptTwo : {0}", ptOne > ptTwo);

            Console.ReadLine();
        }
    }
}
