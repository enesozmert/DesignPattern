using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facade design pattern!");
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    public interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cache");
        }
    }

    public interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    public interface IAuthorize
    {
        void CheckUser();
    }

    public class Validation : IValidation
    {
        public void Validate() => Console.WriteLine("Validate");
    }

    public interface IValidation
    {
        void Validate();
    }

    class CustomerManager
    {
        private CrossCuttingCuncernsFacade _cuncerns;

        public CustomerManager()
        {
            _cuncerns = new CrossCuttingCuncernsFacade();
        }

        public void Save()
        {
            _cuncerns.Authorize.CheckUser();
            _cuncerns.Caching.Cache();
            _cuncerns.Logging.Log();
            _cuncerns.Validation.Validate();
        }

        class CrossCuttingCuncernsFacade
        {
            public ILogging Logging;
            public ICaching Caching;
            public IAuthorize Authorize;
            public IValidation Validation;

            public CrossCuttingCuncernsFacade()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
                Validation = new Validation();
            }
        }
    }
}