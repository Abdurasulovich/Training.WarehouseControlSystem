using Type = Training.WarehouseControlSystem.Domain.Enums.NotificationType;
namespace Training.WarehouseControlSystem.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public string Subject { get; set; } = default!;

    public EmailTemplate() => Type = Type.Email;
}