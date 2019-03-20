using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    enum EmpType
    {
        Manager,      // = 0
        Grunt,        // = 1
        Contractor,   // = 2
        VicePresident // = 3
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Enums *****");
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));
            Console.WriteLine("emp is a {0}.", emp.ToString());
            Console.WriteLine("{0} = {1}", emp.ToString(), (byte) emp);
            Console.WriteLine();

            EmpType e2 = EmpType.Contractor;
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);
            Console.ReadLine();

            Console.WriteLine();
        }

        private static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }

        private static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Infomation about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }

            Console.WriteLine();
        }
    }
}
