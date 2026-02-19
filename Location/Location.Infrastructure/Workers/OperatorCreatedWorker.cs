using Location.Infrastructure.Messaging;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Messaging.Contracts.Messaging;
using Messaging.Contracts.Events.Operator;
using Microsoft.Extensions.DependencyInjection;
using Location.Infrastructure.Persistence;
using Location.Infrastructure.Persistence.Entities;
using System.Transactions;

namespace Location.Infrastructure.Workers
{
    public sealed class OperatorCreatedWorker(IRabbitMqPersistentConnection connection,IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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
                queue: Queues.OpeartorCreatedQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            await channel.QueueBindAsync(
                queue: Queues.OpeartorCreatedQueue,
                exchange: Exchange.OperatorEvent,
                routingKey: RoutingKeys.OperatorCreated,
                cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    using var scope = scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var oper = JsonSerializer.Deserialize<OperatorCreatedEvent>(json);

                    if (oper is null) throw new ArgumentException("Deserialize OperatorCreatedEvent Fail");

                    var data = new List<OperatorLocation>();
                    foreach(var loc in oper.LocationId)
                    {
                        data.Add(new OperatorLocation 
                        {
                            location_id = loc,
                            operator_id = oper.OperatorId,
                            is_active = true,
                        });
                    }
                    await context.operator_location.AddRangeAsync(data);
                    await context.SaveChangesAsync();

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: Queues.OpeartorCreatedQueue,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
