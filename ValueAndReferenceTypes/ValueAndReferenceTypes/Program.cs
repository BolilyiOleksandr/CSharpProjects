using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Assigning value types\n");

            Point p1 = new Point(10, 10);
            Point p2 = p1;

            p1.Display();
            p2.Display();

            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();

            Console.WriteLine("Assigning reference types\n");
            PointRef pr1 = new PointRef(10, 10);
            PointRef pr2 = pr1;

            pr1.Display();
            pr2.Display();

            pr1.X = 100;
            Console.WriteLine("\n=> Changed pr1.X\n");
            pr1.Display();
            pr2.Display();
            Console.WriteLine();

            ValueTypeContainingsRefType();

            Console.ReadLine();
        }
        private static void ValueTypeContainingsRefType()
        {
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);
            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;
            Console.WriteLine("-> Changing values of r2");
            r2.rectInfo.infoString = "This is new info!";
            r2.rectBottom = 444;
            r1.Display();
            r2.Display();
        }
    }

    struct Point
    {
        public int X;
        public int Y;

        public Point(int pointX, int pointY)
        {
            X = pointX;
            Y = pointY;
        }

        public void Increase()
        {
            X++;
            Y++;
        }

        public void Decrease()
        {
            X--;
            Y--;
        }

        public void Display()
        {
            Console.WriteLine("X: {0}, Y: {1}", X, Y);
        }
    }

    internal class PointRef
    {
        public int X;
        public int Y;

        public PointRef(int pointX, int pointY)
        {
            X = pointX;
            Y = pointY;
        }

        public void Increase()
        {
            X++;
            Y++;
        }

        public void Decrease()
        {
            X--;
            Y--;
        }

        public void Display()
        {
            Console.WriteLine("X: {0}, Y: {1}", X, Y);
        }
    }

    internal class ShapeInfo
    {
        public string infoString;

        public ShapeInfo(string info)
        {
            infoString = info;
        }
    }

    struct Rectangle
    {
        public ShapeInfo rectInfo;
        public int rectTop, rectLeft, rectBottom, rectRight;

        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            rectInfo = new ShapeInfo(info);
            rectTop = top;
            rectBottom = bottom;
            rectLeft = left;
            rectRight = right;
        }

        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}", rectInfo.infoString, rectTop, rectBottom, rectLeft, rectRight);
        }
    }
}
