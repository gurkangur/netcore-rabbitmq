using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer.ExchangeTypes
{
    public static class DirectExchange
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "direct-exchange", type: ExchangeType.Direct,
                durable: true, autoDelete: false, arguments: null);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Message : {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish(exchange: "direct-exchange", routingKey: "payment", 
                    basicProperties: null, body: body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
