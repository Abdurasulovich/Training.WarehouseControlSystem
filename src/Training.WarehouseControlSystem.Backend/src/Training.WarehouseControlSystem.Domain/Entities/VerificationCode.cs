using System.Runtime.CompilerServices;
using System.Text;
using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public abstract class VerificationCode : Entity
{
    public VerificationCodeType CodeType { get; set; }
    
    public VerificationType Type { get; set; }
    
    public DateTimeOffset ExpiryTime { get; set; }
    
    public bool IsActive { get; set; }

    public string Code { get; set; } = default!;

    public string VerificationLink { get; set; } = default!;
}