using System;
using System.Net.Http.Headers;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Null Object design patter!");
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("CustomerManager Logged");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged for log4net!");
        }
    }

    class NLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged for Nlogger!");
        }
    }

    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        public StubLogger()
        {
        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }

            return _stubLogger;
        }

        public void Log()
        {
        }
    }

    class CustomerMangerTest
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}