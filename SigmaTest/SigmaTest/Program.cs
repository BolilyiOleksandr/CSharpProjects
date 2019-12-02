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
        }

        private static void BlackAndWhiteImages(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var result = "EVEN";
                var previousValue = "";
                var currentValue = "";

                if (input[i] == null)
                {
                    continue;
                }

                if (input[i].ToUpper() != "END")
                {
                    for (var j = 0; j < input[i].Length; j++)
                    {
                        if (input[i][j] == Convert.ToChar("*"))
                        {
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

                            previousValue = currentValue;
                            currentValue = "";
                            continue;
                        }
                        else
                        {
                            currentValue += input[i][j];
                        }
                    }
                    Console.WriteLine(i + 1 + " " + result);
                }
            }
        }

    }
}
