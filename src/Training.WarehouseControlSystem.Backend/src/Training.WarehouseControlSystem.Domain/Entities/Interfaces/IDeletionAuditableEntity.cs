namespace Training.WarehouseControlSystem.Domain.Entities.Interfaces;

public interface IDeletionAuditableEntity
{
    public Guid? DeletedByUserId { get; set; }
}
