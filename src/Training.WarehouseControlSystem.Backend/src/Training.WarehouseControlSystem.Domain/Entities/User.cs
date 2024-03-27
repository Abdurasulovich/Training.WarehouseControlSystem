namespace Training.WarehouseControlSystem.Domain.Entities;

public class User : Entity
{
    public string FirstName = string.Empty;

    public string LastName = string.Empty;

    public string username = string.Empty;

    public string? Email = string.Empty;

    public string PhoneNumber = string.Empty;
    
    public string Password = string.Empty;

    public Guid ProductId { get; set; }

    public IList<Product> Products { get; set;}

    public DateTimeOffset CreatedAt;

    public DateTimeOffset UpdatedAt;

}
