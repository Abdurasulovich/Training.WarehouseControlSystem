namespace Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;

public interface IAuditableEntity : ISoftDeleteEntity
{
    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset? ModifiedTime { get; set; }
}