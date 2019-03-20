using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Init Syntax *****\n:");

            var firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            var anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();

            var finalPoint = new Point
            {
                X = 30,
                Y = 30
            };
            finalPoint.DisplayStats();

            var goldPoint = new Point(PointColor.Gold)
            {
                X = 90,
                Y = 20
            };
            goldPoint.DisplayStats();

            var myRect = new Rectangle
            {
                TopLeft = new Point
                {
                    X = 10,
                    Y = 10
                },
                BottomRight = new Point
                {
                    X = 200,
                    Y = 200
                }
            };

            Console.ReadLine();
        }
    }

    enum PointColor
    {
        LightBlue, BloodRed, Gold
    }
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }

        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }

        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }

        public Point() : this(PointColor.BloodRed) { }

        public void DisplayStats()
        {
            Console.WriteLine("[{0}, {1}]", X, Y);
            Console.WriteLine("Point is {0}", Color);
        }
    }

    internal class Rectangle
    {
        private Point _topLeft = new Point();
        private Point _bottomRight = new Point();

        public Point TopLeft
        {
            get => _topLeft;
            set => _topLeft = value;
        }

        public Point BottomRight
        {
            get => _bottomRight;
            set => _bottomRight = value;
        }

        public void DisplayStats()
        {
            Console.WriteLine("[TopLeft: {0}, {1}, {2} BottomRight: {3}, {4}, {5}", TopLeft.X, TopLeft.Y, TopLeft.Color,
                BottomRight.X, BottomRight.Y, BottomRight.Color);
            ;
        }
    }
}
