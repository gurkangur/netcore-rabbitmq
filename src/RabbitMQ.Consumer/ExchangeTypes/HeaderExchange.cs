using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer.ExchangeTypes
{
    public static class HeaderExchange
    {
        public static void Receive(IModel channel)
        {
            channel.ExchangeDeclare("header-exchange", ExchangeType.Headers);
            channel.QueueDeclare("header-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(queue: "header-queue",
               exchange: "header-exchange",
               routingKey: "");
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "header-queue", autoAck: true, consumer: consumer);
            Console.WriteLine("Header consumer started..");
        }
    }
}
