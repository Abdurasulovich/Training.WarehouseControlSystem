using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Api.Dto.Products;

public class ProductCreateDto
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

    public Guid CustomerId { get; set; }
}