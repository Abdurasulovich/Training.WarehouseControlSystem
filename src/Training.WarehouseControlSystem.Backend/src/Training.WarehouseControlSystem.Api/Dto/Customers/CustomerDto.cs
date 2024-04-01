namespace Training.WarehouseControlSystem.Api.Dto.Customers;

public class CustomerDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? SecondPhoneNumber { get; set; } = string.Empty;

    public int GeneratedId { get; set; }

    public string Description { get; set; } = string.Empty;
}