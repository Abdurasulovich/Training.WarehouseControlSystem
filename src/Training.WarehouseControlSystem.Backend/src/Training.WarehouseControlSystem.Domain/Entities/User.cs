namespace Training.WarehouseControlSystem.Domain.Entities;

public class User : Entity
{
    public string FirstName = string.Empty;

    public string LastName = string.Empty;

    public string username = string.Empty;

    public string? EmailAddress = string.Empty;

    public string PhoneNumber = string.Empty;
    
    public string Password = string.Empty;

    public IList<Product> Products { get; set;}

    public DateTimeOffset CreatedAt;

    public DateTimeOffset UpdatedAt;

}
