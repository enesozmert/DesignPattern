using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proxy design patter!");
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());
        }

        #region TodoRegion

        //TODO : Cach ile benzer bir işlem bir kere çağrıldıktan sonra bir dah çağrılmaz.
        //TODO : Olay CreditManagerProxy den sürdürülür.

        #endregion
        
        abstract class CreditBase
        {
            public abstract int Calculate();
            
        }

        class CreditManager:CreditBase
        {
            public override int Calculate()
            {
                int result = 1;
                for (int i = 1; i < 5; i++)
                {
                    result *= i;
                    Thread.Sleep(1000);
                }

                return result;
            }
        }

        class CreditManagerProxy:CreditBase
        {
            private CreditManager _creditManager; //injection yapılır burası
            private int _cachedValue;
            public override int Calculate()
            {
                if (_creditManager==null)
                {
                    _creditManager = new CreditManager();
                    _cachedValue = _creditManager.Calculate();
                }

                return _cachedValue;
            }
        }
    }
}