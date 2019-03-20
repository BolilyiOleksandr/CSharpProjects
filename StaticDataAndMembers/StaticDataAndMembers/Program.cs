using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Data *****\n");
            var s1 = new SavingsAccount(50);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());

            SavingsAccount.SetInterestRate(0.08);
            var s2 = new SavingsAccount(100);

            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);

            Console.ReadLine();
        }
    }

    internal class SavingsAccount
    {
        public double _currBalance;
        private static double _currInterestRate = 0.04;

        public static double InterestRate
        {
            get => _currInterestRate;
            set => _currInterestRate = value;
        }

        public SavingsAccount(double balance)
        {
            _currBalance = balance;
        }

        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            _currInterestRate = 0.04;
        }

        public static void SetInterestRate(double newRate)
        {
            _currInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return _currInterestRate;
        }
    }
}
