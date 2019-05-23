using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    internal class Person
    {
        #region Variables
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        #endregion

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Person() { }

        /// <summary>
        /// The overloaded constructor.
        /// </summary>
        /// <param name="name">Name value.</param>
        /// <param name="surname">Surname value.</param>
        /// <param name="age">Age value.</param>
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
