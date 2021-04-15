using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Producer.ExchangeTypes;
using System;
using System.Text;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            FanoutExchange.Publish(channel);
        }
    }
}
