namespace Training.WarehouseControlSystem.Application.Common.Identity.Models;

public class SignInDetails
{
    public string UserName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
