using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer.ExchangeTypes
{
    static class FanoutExchange
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "fanout-exchange", type: ExchangeType.Fanout);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Message: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "fanout-exchange",
                                      routingKey: "",
                                      basicProperties: null,
                                      body: body);

                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
