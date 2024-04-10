using Training.WarehouseControlSystem.Application.Common.Notifications.Models;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Events;

public class SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}
