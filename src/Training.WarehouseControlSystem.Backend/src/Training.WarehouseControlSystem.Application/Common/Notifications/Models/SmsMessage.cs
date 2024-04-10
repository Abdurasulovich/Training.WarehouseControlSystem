using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Models;

public class SmsMessage : NotificationMessage
{
    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!; 

    public SmsTemplate Template { get; set; } = default!;

    public string Message { get; set; } = default!;
}
