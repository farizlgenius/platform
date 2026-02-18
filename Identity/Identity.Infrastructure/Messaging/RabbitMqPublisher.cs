using Identity.Application.Interfaces;
using Identity.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading;


namespace Identity.Infrastructure.MessageBroker
{
    public sealed class RabbitMqPublisher(IRabbitMqPersistentConnection connection) : IMessagePublisher
    {

        public async Task PublishAsync<T>(T message)
        {
            var conn = await connection.GetConnectionAsync();
            await using var channel = await conn.CreateChannelAsync();

            var queueName = typeof(T).Name;

            Console.WriteLine(queueName);

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                body: body
                );
        }


    }
}
