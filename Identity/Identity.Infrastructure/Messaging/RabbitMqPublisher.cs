using Identity.Application.Interfaces;
using Identity.Infrastructure.Messaging;
using Messaging.Contracts;
using Messaging.Contracts.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading;


namespace Identity.Infrastructure.MessageBroker
{
    public sealed class RabbitMqPublisher(IRabbitMqPersistentConnection connection) : IMessagePublisher
    {

        public async Task PublishAsync<T>(T message,string routeKey,CancellationToken ct = default)
        {
            var conn = await connection.GetConnectionAsync(ct);
            await using var channel = await conn.CreateChannelAsync(cancellationToken:ct);


            await channel.ExchangeDeclareAsync(
                exchange: Exchange.OperatorEvent,
                type:ExchangeType.Topic,
                durable:true,
                autoDelete:false,
                cancellationToken: ct
                );



            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            await channel.BasicPublishAsync(
                exchange: Exchange.OperatorEvent,
                routingKey: routeKey,
                body: body,
                 cancellationToken: ct
                );
        }


    }
}
