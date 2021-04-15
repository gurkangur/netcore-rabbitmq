using RabbitMQ.Client;
using RabbitMQ.Consumer.ExchangeTypes;
using System;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel(); 
            FanoutExchange.Receive(channel);
            Console.ReadLine();
        }
    }
}
