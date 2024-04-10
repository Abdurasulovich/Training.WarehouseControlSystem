namespace Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;

public interface IEventSubscriber
{
    ValueTask StartAsyn(CancellationToken cancellationToken);

    ValueTask StopAsyn(CancellationToken cancellationToken);
}
