namespace Training.WarehouseControlSystem.Domain.Entities;

public class Customer : Entity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? SecondPhoneNumber { get; set; } = string.Empty;

    public int GeneratedId { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid ProductId { get; set; }

    public IList<Product> Products { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset UpdatedDate { get; set; } 
}
