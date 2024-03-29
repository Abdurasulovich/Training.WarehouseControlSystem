namespace Training.WarehouseControlSystem.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string username { get; set; } = string.Empty;

    public string? EmailAddress { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public IList<Product> Products { get; set;}

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
