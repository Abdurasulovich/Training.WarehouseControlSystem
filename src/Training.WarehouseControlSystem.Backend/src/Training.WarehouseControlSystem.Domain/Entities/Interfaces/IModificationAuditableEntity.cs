namespace Training.WarehouseControlSystem.Domain.Entities.Interfaces;

public interface IModificationAuditableEntity
{
    public Guid ModifiedByUserId { get; set; }
}
