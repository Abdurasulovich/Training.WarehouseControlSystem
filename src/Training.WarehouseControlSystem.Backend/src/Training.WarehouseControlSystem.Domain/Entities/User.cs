using Training.WarehouseControlSystem.Domain.Common.Entities;

namespace Training.WarehouseControlSystem.Domain.Entities;

public sealed class User : Entity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string username { get; set; } = string.Empty;

    public string? EmailAddress { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    
    public IList<Role> Roles { get; set; }
    
    public UserSettings UserSettings { get; set; }
    
    public UserCredentials UserCredentials { get; set; }

    public IList<Product> Products { get; set;}

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
