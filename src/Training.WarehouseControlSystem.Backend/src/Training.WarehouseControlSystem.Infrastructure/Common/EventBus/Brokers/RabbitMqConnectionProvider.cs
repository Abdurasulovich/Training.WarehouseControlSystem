using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;
using Training.WarehouseControlSystem.Domain.Common.Events;
using Training.WarehouseControlSystem.Infrastructure.Common.Settings;

namespace Training.WarehouseControlSystem.Infrastructure.Common.EventBus.Brokers;

public class RabbitMqConnectionProvider : IRabbitMqConnectionProvider
{
    public ConnectionFactory _connectionFactory;

    private IConnection? _connection;

    public RabbitMqConnectionProvider(IOptions<RabbitMqConnectionSettings> rabbitMqConnectionSettings)
    {
        var rabbitMqConnectionSetting = rabbitMqConnectionSettings.Value;
        _connectionFactory = new ConnectionFactory()
        {
            HostName = rabbitMqConnectionSetting.HostName,
            Port = rabbitMqConnectionSetting.Port
        };
    }

    public async ValueTask<IChannel> CreateChannelAsync()
    {
        _connection ??= await _connectionFactory.CreateConnectionAsync();
        return await _connection.CreateChannelAsync();
    }
}