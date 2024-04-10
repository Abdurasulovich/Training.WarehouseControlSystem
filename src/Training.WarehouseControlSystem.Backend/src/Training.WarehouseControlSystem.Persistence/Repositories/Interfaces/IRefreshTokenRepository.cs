using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    ValueTask<RefreshToken> CreateAsync(
        RefreshToken refreshToken,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<RefreshToken?> GetByValueAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken = default);

    ValueTask RemoveAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken = default);
}
