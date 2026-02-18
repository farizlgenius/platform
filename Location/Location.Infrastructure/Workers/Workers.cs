using Location.Domain.Events;
using Location.Infrastructure.Messaging;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Location.Infrastructure.Workers
{
    public sealed class Workers(IRabbitMqPersistentConnection connection) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conn = await connection.GetConnectionAsync(stoppingToken);
            var channel = await conn.CreateChannelAsync(cancellationToken: stoppingToken);

            var queueName = nameof(OperatorCreatedEvent);

            Console.WriteLine(queueName);

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var oper = JsonSerializer.Deserialize<OperatorCreatedEvent>(json);

                    Console.WriteLine($"Processing Order {oper?.operatorId}");

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);
        }
    }
}
