using Identity.Application.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Messaging
{
    public interface IRabbitMqPersistentConnection : IDisposable
    {
        Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default);
    }

    public sealed class RabbitMqPersistentConnection : IRabbitMqPersistentConnection
    {
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private readonly object _lock = new();

        public RabbitMqPersistentConnection(IOptions<RabbitMqSetting> options)
        {
            var settings = options.Value;

            _factory = new ConnectionFactory
            {
                HostName = settings.Host,
                Port = settings.Port,
                UserName = settings.Username,
                Password = settings.Password,
                VirtualHost = settings.VirtualHost,
                //DispatchConsumersAsync = true,
                RequestedConnectionTimeout = TimeSpan.FromSeconds(10),
                SocketReadTimeout = TimeSpan.FromSeconds(10),
                SocketWriteTimeout = TimeSpan.FromSeconds(10)
            };
        }
        public void Dispose()
        {
            if (_connection?.IsOpen == true)
                _connection.Dispose();
        }

        public async Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
        {
            if (_connection != null && _connection.IsOpen)
                return _connection;

            lock (_lock)
            {
                if (_connection != null && _connection.IsOpen)
                    return _connection;
            }

            try
            {
                _connection = await _factory.CreateConnectionAsync(cancellationToken);
                return _connection;
            }
            catch (BrokerUnreachableException ex)
            {
                throw new Exception("RabbitMQ unreachable", ex);
            }
        }
    }
}
