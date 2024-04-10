using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Identity.Services;

public interface IIdentitySecurityTokenGeneratorService
{
    AccessToken GenerateAccessToken(User user);

    RefreshToken GenerateRefreshToken(User user, bool extendedExpiryTime = false);

    (AccessToken accessToken, bool IsExpired)? GetAccessToken(string tokenValue);

    Guid GetAccessTokenId(string accessToken);

    JwtSecurityToken GetToken(User user, AccessToken accessToken);

    List<Claim> GetClaims(User user, AccessToken accessToken);
}
