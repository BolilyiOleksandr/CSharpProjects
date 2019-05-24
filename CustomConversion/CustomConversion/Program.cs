using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Conversions *****\n");

            var r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            var s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();

            var sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);

            var side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);

            var s3 = new Square();
            s3.Length = 7;
            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}", rect2);

            var s4 = new Square();
            s4.Length = 3;
            Rectangle rect3 = (Rectangle)s4;
            Console.WriteLine("rect3 - {0}", rect3);

            Console.ReadLine();
        }
    }

    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Width = {0}; Height = {1}]", Width, Height);
        }

        public static implicit operator Rectangle(Square s)
        {
            var r = new Rectangle();
            r.Height = s.Length;

            r.Width = s.Length * 2;
            return r;
        }

    }

    public struct Square
    {
        public int Length { get; set; }

        public Square(int l) : this()
        {
            Length = l;
        }

        public void Draw()
        {
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Length = {0}]", Length);
        }

        public static explicit operator Square(Rectangle r)
        {
            var s = new Square()
            {
                Length = r.Height
            };

            return s;
        }

        public static explicit operator Square(int sideLength)
        {
            var newSq = new Square();
            newSq.Length = sideLength;
            return newSq;
        }

        public static explicit operator int(Square s)
        {
            return s.Length;
        }

    }

}
