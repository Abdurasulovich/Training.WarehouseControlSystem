using Training.WarehouseControlSystem.Domain.Common.Entities;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class RefreshToken : Entity
{
    public Guid UserId { get; set; }

    public string Token { get; set; } = default!;
    
    public DateTimeOffset ExpiryTime { get; set; }
    
    public bool EnableExtendedExpiryTime { get; set; }

}