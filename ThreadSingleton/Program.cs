using System;

namespace ThreadSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Singleton");
            var customerManager=CustomerManger.CreateAsSingleton();
            var customerManager1=CustomerManger.CreateAsSingleton();
            customerManager.Save();
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
        //TODO:Lock ile  singleton da  tek örnek oluşturmak
        #endregion
        
        class CustomerManger
        {
            private static CustomerManger _customerManger;
            private static object _lockObject = new Object();
            private CustomerManger()
            {
                
            }

            public static CustomerManger CreateAsSingleton()
            {
                //return _customerManger ?? (_customerManger = new CustomerManger());
                lock (_lockObject)
                {
                    if (_customerManger==null)
                    {
                        _customerManger = new CustomerManger();
                    }
                }

                return _customerManger;
            }

            public void Save() => Console.WriteLine("Saved!");
            public void Save(int number) => Console.WriteLine("Saved!"+number);
        }
    }
}