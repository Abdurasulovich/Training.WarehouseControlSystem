using Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Domain.Common.Entities;

public abstract class SoftDeletedEntity : Entity, ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedTime { get; set; }
}