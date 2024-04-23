using System.Text;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using Training.WarehouseControlSystem.Application.Common.EventBus.Brokers;
using Training.WarehouseControlSystem.Application.Common.Serializers;
using Training.WarehouseControlSystem.Domain.Common.Events;

namespace Training.WarehouseControlSystem.Infrastructure.Common.EventBus.Brokers;

public class RabbitMqEventBusBroker(
    IRabbitMqConnectionProvider rabbitMqConnectionProvider,
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider,
    IPublisher mediator
    ) : IEventBusBroker
{
    public ValueTask PublishLocalAsync<TEvent>(TEvent command) where TEvent : IEvent
    {
        return new ValueTask(mediator.Publish(command));
    }

    public async ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken) where TEvent : Event
    {
        var channel = await rabbitMqConnectionProvider.CreateChannelAsync();

        var properties = new BasicProperties()
        {
            Persistent = true
        };

        var serializerSettings = jsonSerializationSettingsProvider.Get(true);
        serializerSettings.ContractResolver = new DefaultContractResolver();
        serializerSettings.TypeNameHandling = TypeNameHandling.All;

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, serializerSettings));
        await channel.BasicPublishAsync(exchange, routingKey, properties, body);
    }
}