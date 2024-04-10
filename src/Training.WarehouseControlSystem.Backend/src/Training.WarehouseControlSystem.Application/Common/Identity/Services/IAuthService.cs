﻿using Training.WarehouseControlSystem.Application.Common.Identity.Models;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Identity.Services;
public interface IAuthService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);

    ValueTask<(AccessToken accessToken, RefreshToken refreshToken)> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default);

    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, CancellationToken cancellationToken = default);

    ValueTask<bool> RevokeRoleAsync(Guid userId, string roleType, CancellationToken cancellationToken= default);

    ValueTask<AccessToken> RefreshTokenAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken = default);
}
