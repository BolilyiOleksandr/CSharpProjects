using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal partial class Employee
    {
        #region Constructors
        public Employee() { }
        public Employee(string name, int id, float pay, int age)
        {
            Name = name;
            Age = age;
            Id = id;
            Pay = pay;
        }
        #endregion

        #region Methods
        public void GiveBonus(float amount)
        {
            _currPay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", _empName);
            Console.WriteLine("ID: {0}", _empId);
            Console.WriteLine("Pay: {0}", _currPay);
            Console.WriteLine("Age: {0}", _empAge);
        }

        public string GetName()
        {
            return _empName;
        }

        public void SetName(string name)
        {
            if (name.Length > 15)
            {
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            }
            else
            {
                _empName = name;
            }
        }
        #endregion
    }
}
