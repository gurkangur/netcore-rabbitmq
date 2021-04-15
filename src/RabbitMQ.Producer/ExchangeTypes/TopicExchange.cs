using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer.ExchangeTypes
{
    public static class TopicExchange
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic);
            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Message: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "topic-exchange", routingKey: "account.key",
                    basicProperties: null, body: body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
