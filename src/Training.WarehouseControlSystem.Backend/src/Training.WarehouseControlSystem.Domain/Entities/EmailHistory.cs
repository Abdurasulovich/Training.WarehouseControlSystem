using Type = Training.WarehouseControlSystem.Domain.Enums.NotificationType;
namespace Training.WarehouseControlSystem.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory() => Type = Type.Email;

    public string SenderEmailAddress { get; set; }

    public string ReceiverEmailAddress { get;set; }

    public string Subject { get; set; }

    public EmailTemplate Template { get; set; }
}
