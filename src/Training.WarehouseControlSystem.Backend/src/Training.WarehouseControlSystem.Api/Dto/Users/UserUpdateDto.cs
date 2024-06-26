﻿namespace Training.WarehouseControlSystem.Api.Dto.Users;

public class UserUpdateDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string username { get; set; }

    public string PhoneNumber { get; set; }
    
    public string EmailAddress { get; set; }
    
    public string Password { get; set; }
}