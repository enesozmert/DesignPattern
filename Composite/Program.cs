using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composite design pattern!");
            Employee engin = new Employee {Name = "Engin Demiroğ"};
            Employee engin1 = new Employee {Name = "Engin Demiroğ1"};
            Employee engin2 = new Employee {Name = "Engin Demiroğ2"};
            Employee engin3 = new Employee {Name = "Engin Demiroğ3"};

            engin.AddSubordinate(engin1);
            engin1.AddSubordinate(engin2);
            engin2.AddSubordinate(engin3);

            foreach (Employee manager in engin)
            {
                Console.WriteLine(manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("manager" + employee.Name);
                }
            }
        }

        #region TodoRegion

        //TODO : Nesneler arası hiyerarşi yanı dallanma örneği aklımıza gelmelidir. 

        #endregion

        interface IPerson
        {
            string Name { get; set; }
        }

        class Employee : IPerson, IEnumerable<IPerson>
        {
            private List<IPerson> _subordinates = new List<IPerson>();
            public string Name { get; set; }

            public void AddSubordinate(IPerson person)
            {
                _subordinates.Add(person);
            }

            public void RemoveSubordinate(IPerson person)
            {
                _subordinates.Remove(person);
            }

            public IPerson GetSubordinate(int index)
            {
                return _subordinates[index];
            }

            public IEnumerator<IPerson> GetEnumerator()
            {
                foreach (var subordinate in _subordinates)
                {
                    yield return subordinate;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}