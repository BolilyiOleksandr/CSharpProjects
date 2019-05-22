using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionMultipleParams
{
    public delegate string VerySimpleDelegate();
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m = new SimpleMath();
            m.SetMathHandler((msg, result) => { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            m.Add(10, 10);

            var d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
            Console.WriteLine(d());

            Console.ReadLine();
        }
    }
}
