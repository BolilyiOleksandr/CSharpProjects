using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal partial class Employee
    {
        #region Variables
        private string _empName;
        private int _empId;
        private float _currPay;
        private int _empAge;
        private string _empSsn;
        #endregion

        #region Properties
        public string Name
        {
            get => _empName;
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                    _empName = value;
            }
        }

        public int Id
        {
            get => _empId;
            set => _empId = value;
        }

        public float Pay
        {
            get => _currPay;
            set => _currPay = value;
        }

        public int Age
        {
            get => _empAge;
            set => _empAge = value;

        }

        public string SocialSecurityNumber
        {
            get => _empSsn;
        }
        #endregion
    }
}
