using Training.WarehouseControlSystem.Domain.Common.Events;

namespace Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;

public interface IEventBusBroker
{
    ValueTask PublishLocalAsync<TEvent>(TEvent command) where TEvent : IEvent;

    ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken) where TEvent : Event;
}
