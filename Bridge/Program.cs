using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bridge design pattern!");
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpadeteCustomer();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        //Send yönetime köprü yapıyoruz
        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }
    //...

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpadeteCustomer()
        {
            //SmsSender smsSender = new SmsSender(); kötü kod burasıdır.
            MessageSenderBase.Send(new Body {Title = "About the course!"});
            Console.WriteLine("Customer updated");
        }
    }

    class NewCustomerManager:CustomerManager
    {
        
    }
}