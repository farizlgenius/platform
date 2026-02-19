using Location.Infrastructure.Messaging;
using Location.Infrastructure.Persistence;
using Location.Infrastructure.Persistence.Entities;
using Messaging.Contracts.Events.Operator;
using Messaging.Contracts.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Location.Infrastructure.Workers
{
    public sealed class OperatorDeletedWorker(IRabbitMqPersistentConnection connection, IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conn = await connection.GetConnectionAsync(stoppingToken);
            var channel = await conn.CreateChannelAsync(cancellationToken: stoppingToken);


            // Declare Exchange
            await channel.ExchangeDeclareAsync(
                exchange: Exchange.OperatorEvent,
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false,
                cancellationToken: stoppingToken);

            // Declare Queue
            await channel.QueueDeclareAsync(
                queue: Queues.OperatorDeletedQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            await channel.QueueBindAsync(
                queue: Queues.OperatorDeletedQueue,
                exchange: Exchange.OperatorEvent,
                routingKey: RoutingKeys.OperatorDeleted,
                cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    using var scope = scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var oper = JsonSerializer.Deserialize<OperatorDeletedEvent>(json);

                    if (oper is null) throw new ArgumentException("Deserialize OperatorCreatedEvent Fail");

                    var en = await context.operator_location.Where(x => x.operator_id == oper.OperatorId).ToArrayAsync();
                    context.operator_location.RemoveRange(en);
                    await context.SaveChangesAsync();

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: Queues.OperatorDeletedQueue,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
