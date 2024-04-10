using Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Domain.Common.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
