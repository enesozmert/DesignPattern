using System;
using System.Security.Principal;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Desing Pattern");
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            
        }

        #region TodoRegion
            //TODO : En popüler olan desing pattern
            //TODO : Bizim bir fabrikamızın olması temel olay

        

        #endregion

        public class LoggerFactory:ILoggerFactory
        {
            public ILogger CreaterLogger()
            { 
                //Business to decide factory
                //İş geliştirme kısmı burasıdır.
                return new EdLogger();
            }
        }
        public class LoggerFactory2:ILoggerFactory
        {
            public ILogger CreaterLogger()
            { 
                //Business to decide factory
                //İş geliştirme kısmı burasıdır.
                return new EdLogger2();
            }
        }
        public interface ILoggerFactory
        {
            ILogger CreaterLogger();
        }
        public interface ILogger
        {
            void Log();
        }

        public class EdLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged with EdLogger");
            }
        }
        public class EdLogger2 : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged with EdLogger2");
            }
        }

        public class CustomerManager
        {
            private ILoggerFactory _loggerFactory;

            public CustomerManager(ILoggerFactory loggerFactory)
            {
                _loggerFactory = loggerFactory;
            }

            public void Save()
            {
                Console.WriteLine("Saved");
                ILogger logger = _loggerFactory.CreaterLogger();
                logger.Log();
            }
        }
    }
}