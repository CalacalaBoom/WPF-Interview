using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    public delegate void MessageReceivedEventHandler(string message);
    public class Publisher
    {
        public event MessageReceivedEventHandler MessageRecived;

        public void SendMessage(string message)
        {
            MessageRecived?.Invoke(message);
        }
    }

    public class Subscriber
    {
        public void Subscribe(Publisher publisher)
        {
            publisher.MessageRecived += Publisher_MessageRecived;
        }

        private void Publisher_MessageRecived(string message)
        {
            Console.WriteLine($"Recevid Message:{message}");
        }
    }
}
