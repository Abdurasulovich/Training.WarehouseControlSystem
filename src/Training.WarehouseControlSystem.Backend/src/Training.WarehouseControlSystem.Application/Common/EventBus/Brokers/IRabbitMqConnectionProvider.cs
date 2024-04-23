using RabbitMQ.Client;
using Training.WarehouseControlSystem.Domain.Common.Events;

namespace Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;

public interface IRabbitMqConnectionProvider
{
    ValueTask<IChannel> CreateChannelAsync();
}
