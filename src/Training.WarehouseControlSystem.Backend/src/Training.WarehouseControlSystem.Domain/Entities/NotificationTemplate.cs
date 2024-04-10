using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public abstract class NotificationTemplate : AuditableEntity
{
    public string Content { get; set; } = default!;
    
    public NotificationType Type { get; set; }
    
    public NotificationTemplate TemplateType { get; set; }
}