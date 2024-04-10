using MediatR;

namespace Training.WarehouseControlSystem.Domain.Common.Events;

public interface IEvent : INotification
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public bool Redelivered { get; set; }
}
