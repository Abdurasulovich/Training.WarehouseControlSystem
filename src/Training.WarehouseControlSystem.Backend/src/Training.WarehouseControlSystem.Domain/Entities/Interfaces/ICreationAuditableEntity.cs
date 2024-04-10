namespace Training.WarehouseControlSystem.Domain.Entities.Interfaces;

public interface ICreationAuditableEntity
{
    public Guid CreatedByUserId { get; set; }
}
