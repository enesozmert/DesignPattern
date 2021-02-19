using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype desing pattern");
            Customer customer = new Customer {FirstName = "Enes", LastName = "Özmert", City = "Kocaeli", Id = 1};

            Customer customer1 = (Customer) customer.Clone();
            customer1.FirstName = "salih";
            
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer1.FirstName);
        }

        #region TodoRegion

        //TODO : Prototip olarak nesne oluşturulur.
        //TODO : Prototip deseninde temel nesneyi prototip yapmak için temel nesne soyutlanır abstract
        //TODO : Kaynağın ortak kullanımı söz konusudur.
        //TODO : Asıl mesele klonlamadır.
        //TODO : Clone işlemi MemberwiseClone ile yapılır ve
        #endregion

        public abstract class Person
        {
            public abstract Person Clone();
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Customer : Person
        {
            public string City { get; set; }

            public override Person Clone()
            {
                return (Person) MemberwiseClone();
            }
        }

        public class Employee : Person
        {
            public string Salary { get; set; }

            public override Person Clone()
            {
                return (Person) MemberwiseClone();
            }
        }
    }
}