using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Application.Common.Verifications.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(
        string code,
        CancellationToken cancellationToken = default);
}
