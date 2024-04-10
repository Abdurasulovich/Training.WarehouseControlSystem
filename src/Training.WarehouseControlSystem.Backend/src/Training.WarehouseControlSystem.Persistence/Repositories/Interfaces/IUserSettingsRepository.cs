using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    IQueryable<UserSettings> Get(
        Expression<Func<UserSettings, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<IList<UserSettings>> GetByIdsAsync(IEnumerable<Guid> ids, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings> CreateAsync(UserSettings userSettings, 
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings> UpdateAsync(
        UserSettings userSettings,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings?> DeleteAsync(
        UserSettings userSettings,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings?> DeleteByIdAsync(
        Guid userSettigsId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
