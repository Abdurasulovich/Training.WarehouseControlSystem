using Training.WarehouseControlSystem.Domain.Common.Events;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Events;

public class NotificationEvent : Event
{
    public Guid SenderUserId { get; init; }

    public Guid ReceiverUserId { get; init; }
}
