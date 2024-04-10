using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Application.Common.Verifications.Services;

public interface IUserVerificationCodeService : IVerificationCodeService
{
    IList<string> Generate();

    ValueTask<(UserInfoVerificationCode code, bool IsValid)> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default);

    ValueTask<UserInfoVerificationCode> CreateAsync(
        VerificationCodeType codeType,
        Guid userId, 
        CancellationToken cancellationToken = default);

    ValueTask DeactivateAsync(Guid userId, bool saveChanges= true,  CancellationToken cancellationToken = default);

}
