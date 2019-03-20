using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Encapsulation ****\n");
            var emp = new Employee("Marvin", 456, 30000, 20);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            emp.Name = "Marv";
            Console.WriteLine("Employee is named: {0}", emp.GetName());

            var emp2 = new Employee();
            emp2.SetName("Xena the warrior princess");

            var joe = new Employee();
            joe.Age++;

            Console.ReadLine();
        }
    }
}
