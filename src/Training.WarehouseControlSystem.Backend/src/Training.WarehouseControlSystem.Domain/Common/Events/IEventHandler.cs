using MediatR;

namespace Training.WarehouseControlSystem.Domain.Common.Events;

public interface IEventHandler<in TEvent> : IEventHandler, INotificationHandler<TEvent> where TEvent : IEvent
{
}

public interface IEventHandler
{
}
