using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract Factory");
            ProductManager productManager = new ProductManager(new Factory1());
            ProductManager productManager1 = new ProductManager(new Factory2());
            productManager.GetAll();
            productManager1.GetAll();
            
        }

        #region TodoRegion
        
            //TODO : evrak takip ve loglama sistemleri için kullanırız.
            //TODO : Abstract bir fabrika oluşturuyoruz.
            
        #endregion
        
        public abstract class CrossCuttingConcernsFactory1
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();

        }
        public class Factory1:CrossCuttingConcernsFactory1
        {
            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }

            public override Caching CreateCaching()
            {
                return new RedisCache();
            }
        }
        public class Factory2:CrossCuttingConcernsFactory1
        {
            public override Logging CreateLogger()
            {
                return new NLogger();
            }

            public override Caching CreateCaching()
            {
                return new RedisCache();
            }
        }

        public abstract class Logging
        {
            public abstract void Log(string message);
        }

        class Log4NetLogger:Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with log4net");
            }
        }
        class NLogger:Logging 
        {
            public override void Log(string message) 
            { 
                Console.WriteLine("Logged with nlogger");
                
            }
        }

        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCache:Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with memche");
            }
        }
        public class RedisCache:Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with redis");
            }
        }
        public class ProductManager
        {
            private Logging _logging;
            private Caching _caching;
            private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory;

            public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _logging = _crossCuttingConcernsFactory.CreateLogger();
                _caching = _crossCuttingConcernsFactory.CreateCaching();
            }

            public void GetAll()
            {
                _logging.Log("Logged");
                _caching.Cache("Data");
                //_crossCuttingConcernsFactory.CreateLogger().Log();
                Console.WriteLine("Product Listed");
            }
        }
        
    }
}