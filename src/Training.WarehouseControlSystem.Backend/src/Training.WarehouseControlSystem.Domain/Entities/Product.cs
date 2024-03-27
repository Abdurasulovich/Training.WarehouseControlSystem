namespace Training.WarehouseControlSystem.Domain.Entities;

public class Product : Entity
{
    public Guid CustumerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public double Price { get; set; }

    public int ProductPlaceId { get; set; }

    public DateTimeOffset ProductIn { get; set; }

    public DateTimeOffset ProductOut { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid AddedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
