using Training.WarehouseControlSystem.Domain.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Domain.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
