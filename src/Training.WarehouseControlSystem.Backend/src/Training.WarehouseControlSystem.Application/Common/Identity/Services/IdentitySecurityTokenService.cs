using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Identity.Services;

public interface IdentitySecurityTokenService
{
    ValueTask<AccessToken> CreateAccessTokenAsync(
        AccessToken accessToken,
        bool saveChanges = true, 
        CancellationToken cancellationToken = default);

    ValueTask<AccessToken?> GetAccessTokenByIdAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken= default);

    ValueTask<RefreshToken> CreateRefreshTokenAsync(
        RefreshToken refreshToken,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<RefreshToken?> GetRefreshTokenByValueAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken = default);

    ValueTask RevokeAccessTokenAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken= default);

    ValueTask RemoveAccessTokenAsync(Guid accessTokenId,
        CancellationToken cancellationToken= default);

    ValueTask RemoveRefreshTokenAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken= default);
}
