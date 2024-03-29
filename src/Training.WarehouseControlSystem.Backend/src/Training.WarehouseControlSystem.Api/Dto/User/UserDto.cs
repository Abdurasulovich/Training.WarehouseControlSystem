namespace Training.WarehouseControlSystem.Api.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string username { get; set; }

    public string PhoneNumber { get; set; }
    
    public string EmailAddress { get; set; }
}