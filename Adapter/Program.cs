using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adapter design pattern!");
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
        }

        #region TodoRegion

        //TODO : Dışarıda ki servisi projede kullanmak ve kullanırken bağımlılığı önelemek amaçlı kullanılıar.
        //TODO : Seneryo yeni bir loglama bulduk projede kullanmak istiyoruz. 1000 tane metotlu ortamda _looger kullanmak yerine
        //TODO : Productmanager de ılogger'ı değiştimeden log4net nasıl eklenir.=>DEVREYE GİRER=>Adaptor Model

        #endregion

        class ProductManager
        {
            private ILogger _logger;

            public ProductManager(ILogger logger)
            {
                _logger = logger;
            }

            public void Save()
            {
                _logger.Log("User Data");
                Console.WriteLine("Saved");
            }
        }

        interface ILogger
        {
            void Log(string message);
        }

        class EdLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logged {0}", message);
            }
        }

        //Nugget packet for=>
        class Log4Net
        {
            public void LogMessage(string message)
            {
                Console.WriteLine("Logged Log4Net");
            }
        }

        class Log4NetAdapter : ILogger
        {
            public void Log(string message)
            {
                Log4Net log4Net = new Log4Net();
                log4Net.LogMessage(message);
            }
        }
        //=>forend
    }
}