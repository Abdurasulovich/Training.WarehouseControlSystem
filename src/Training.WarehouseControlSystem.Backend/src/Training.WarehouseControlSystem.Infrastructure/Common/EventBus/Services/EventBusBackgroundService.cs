using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;

namespace Training.WarehouseControlSystem.Infrastructure.Common.EventBus.Services;

public class EventBusBackgroundService(IEnumerable<IEventSubscriber> eventSubscribers) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.WhenAll(
            eventSubscribers.Select(eventSubscriber => eventSubscriber.StartAsyn(stoppingToken).AsTask()));
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(eventSubscribers.Select(eventSubscriber=>eventSubscriber.StopAsyn(cancellationToken).AsTask()));
    }
}