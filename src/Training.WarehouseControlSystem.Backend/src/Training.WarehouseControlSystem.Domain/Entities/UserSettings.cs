using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class UserSettings : AuditableEntity
{
    public Theme PreferredTheme { get; set; }
    public NotificationType PreferredNotificationType { get; set; }
    
    public Guid UserId { get; set; }

    public virtual User? User { get; set; }
}