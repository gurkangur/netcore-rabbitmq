using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer.ExchangeTypes
{
    public static class TopicExchange
    {
        public static void Receive(IModel channel)
        {
            channel.ExchangeDeclare("topic-exchange", ExchangeType.Topic);
            channel.QueueDeclare("topic-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            channel.QueueBind(queue: "topic-queue",
               exchange: "topic-exchange",
               routingKey: "account.*");
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "topic-queue", autoAck: true, consumer: consumer);
            Console.WriteLine("Topic consumer started..");
        }
    }
}
