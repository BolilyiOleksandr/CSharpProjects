using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicEightBallServiceClient.ServiceReference1;

namespace MagicEightBallServiceClient
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Ask the Magic 8 Ball *****\n");

            using (var ball = new EightBallClient("BasicHttpBinding_IEightBall"))
            {
                Console.Write("Your question: ");
                var question = Console.ReadLine();
                var answer = ball.ObtainAnswerToQuestion(question);
                Console.WriteLine("8-Ball says: {0}", answer);
            }

            Console.ReadLine();
        }
    }
}
