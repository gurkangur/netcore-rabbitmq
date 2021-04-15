using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer.ExchangeTypes
{
    public static class FanoutExchange
    {
        public static void Receive(IModel channel)
        {
            channel.ExchangeDeclare("fanout-exchange", ExchangeType.Fanout);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                          exchange: "fanout-exchange",
                          routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            Console.WriteLine("Fanout consumer started..");
        }
    }
}
