using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton");
            var customerManager=CustomerManger.CreateAsSingleton();
            var customerManager1=CustomerManger.CreateAsSingleton();
            customerManager.Save();
            customerManager1.Save();
            customerManager.Save(1);
            customerManager1.Save(1);
            if (customerManager==customerManager1)
            {
                Console.WriteLine("Singleton true");
            }else{
                Console.WriteLine("Singleton false");
            }
        }

        #region TodoRegion
        //TODO : Kontrol edilmesi-tek örnek
        //TODO : Business de ki Manager nesnesi için instancesi oluşturulmuş örneği kullanmak
        //TODO : Bellekte her zaman sabit kalır.
        //TODO : kullanılan nesneleri singleton üretmemek lazım çünkü yer fazlalılığı oluşturur.
        //TODO :Factory desing patter ile ortak singleton üretme işlemi yapılabilinir.
        #endregion

        class CustomerManger
        {
            private static CustomerManger _customerManger;
            private CustomerManger()
            {
                
            }

            public static CustomerManger CreateAsSingleton()
            {
               return _customerManger ?? (_customerManger = new CustomerManger());
            }

            public void Save() => Console.WriteLine("Saved!");
            public void Save(int number) => Console.WriteLine("Saved!"+number);
        }
        
    }
}