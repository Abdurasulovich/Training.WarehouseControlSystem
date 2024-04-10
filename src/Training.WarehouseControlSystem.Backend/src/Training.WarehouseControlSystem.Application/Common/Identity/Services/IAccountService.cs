using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<User?> GetUserByEmailAddressAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<bool> VerifyUserAsync(string code, CancellationToken cancellationToken = default);
}
