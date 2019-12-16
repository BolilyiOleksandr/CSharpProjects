using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = Solution(6, 20);
            //Console.WriteLine($"Number of integers = {result}\n");

            //var arrayOfInt = new int[] { -1, -3, 4, 7, 7, 7 };
            //var boolResult = Solution(arrayOfInt);
            //Console.WriteLine($"Result is {boolResult}\n");

            var result = Solution(2, "1A 2F 1C");
            Console.WriteLine($"Result is {result}");

            Console.ReadLine();
        }

        private static int Solution(int A, int B)
        {
            var numberOfIntegers = 0;

            if (A >= 1 && B <= 1000000000 && A <= B)
            {
                for (var i = 1; i <= B; i++)
                {
                    var currentValue = i * (i + 1);

                    if (currentValue < A)
                    {
                        continue;
                    }

                    if (currentValue > B)
                    {
                        break;
                    }

                    if (currentValue >= A && currentValue <= B)
                    {
                        numberOfIntegers++;
                    }
                }
            }

            return numberOfIntegers;
        }

        private static bool Solution(int[] A)
        {
            var list = A.ToList<int>();
            var result = false;
            var counter = 0;

            if (list.Count >= 2 && list.Count <= 100000 && list.Count % 2 == 0)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    for (var j = 1; j < list.Count; j++)
                    {
                        var sum = list[i] + list[j];

                        if (sum % 2 == 1)
                        {
                            result = true;
                            counter++;
                            list.RemoveAt(j);
                            list.RemoveAt(i);
                            i = -1;
                            break;
                        }
                    }
                }

                if (result && counter == A.Length / 2)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        private static int Solution(int N, string S)
        {
            var result = 0;

            if (S.Length == 0 && S == "")
            {
                result = 2;
                return result;
            }

            var list = new List<string>();
            list = S.Split(' ').ToList<string>();

            for (var i = 1; i <= N; i++)
            {
                for (var j = 0; j < list.Count; j++)
                {
                    var currentSeat = i + list[j].Substring(list[j].Length - 1);
                    if (currentSeat == i + "C" || currentSeat == i + "H" || currentSeat == i + "E" || currentSeat == i + "H")
                    {
                        result++;
                    }
                }
            }

            return result;
        }

    }
}
