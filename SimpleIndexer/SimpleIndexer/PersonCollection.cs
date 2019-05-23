using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    internal class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        public Person this[int index]
        {
            get { return (Person)arPeople[index]; }
            set { arPeople.Insert(index, value); }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var people in arPeople)
            {
                yield return people;
            }
        }
    }
}
