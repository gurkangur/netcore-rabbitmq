using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer.ExchangeTypes
{
    public static class DirectExchange
    {
        public static void Receive(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "direct-exchange", durable: true, type: ExchangeType.Direct);
            channel.QueueBind(queue: "direct-queue", exchange: "direct-exchange", routingKey: "payment");

            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "direct-queue", autoAck: true, consumer: consumer);
            Console.WriteLine("Direct consumer started..");
        }
    }
}
