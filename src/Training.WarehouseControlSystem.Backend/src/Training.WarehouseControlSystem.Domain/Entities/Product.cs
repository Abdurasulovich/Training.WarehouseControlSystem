using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class Product : Entity
{ 
    public string Name { get; set; } = string.Empty;

    public double Quantity { get; set; }
    
    public ProductType Type { get; set; }

    public double Price { get; set; }

    public int ProductPlaceId { get; set; }

    public DateTimeOffset ProductIn { get; set; }

    public DateTimeOffset ProductOut { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User User { get; set; }

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
