using System.Dynamic;
using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public abstract class NotificationHistory : AuditableEntity
{
    public Guid TemplateId { get; set; }
    
    public Guid SenderUserId { get; set; }
    
    public Guid ReceiverUserId { get; set; }
    
    public NotificationType Type { get; set; }

    public string Content { get; set; } = default!;
    
    public bool IsSuccessful { get; set; } 
    
    public NotificationTemplate? Template { get; set; }
}