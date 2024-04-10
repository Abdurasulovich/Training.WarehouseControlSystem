using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class Role : AuditableEntity
{
    public RoleType Type { get; set; }
    
    public bool IsDisabled { get; set; }
    
    public IList<User> Users { get; set; }
}