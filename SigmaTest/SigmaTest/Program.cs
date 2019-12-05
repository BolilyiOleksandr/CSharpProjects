using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTest
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<string>();
            while (true)
            {
                list.Add(Console.ReadLine());

                if ((list.ToArray()[list.Count - 1].ToUpper() == "END"))
                {
                    BlackAndWhiteImages(list.ToArray());
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void BlackAndWhiteImages(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var result = "EVEN";
                var previousValue = "";
                var currentValue = "";
                var count = 0;

                if (input[i].ToUpper() == "END")
                {
                    break;
                }

                for (var j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == Convert.ToChar("."))
                    {
                        count++;
                        while (input[i][j] != Convert.ToChar("*"))
                        {
                            currentValue += input[i][j];
                            j++;
                        }

                        if (previousValue == "")
                        {
                            previousValue = currentValue;
                        }
                        else
                        {
                            if (previousValue != currentValue)
                            {
                                result = "NOT EVEN";
                                break;
                            }
                        }

                        currentValue = "";
                    }
                }

                if (count % 2 != 0)
                {
                    result = "NOT EVEN";
                }

                Console.WriteLine($"{i + 1} {result}");

            }
        }
    }
}
