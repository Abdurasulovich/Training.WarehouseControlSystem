using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class UserSettingsRespository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserSettings, AppDbContext>(dbContext, cacheBroker, new()),
    IUserSettingsRepository
{
    ValueTask<UserSettings> IUserSettingsRepository.CreateAsync(UserSettings userSettings, bool saveChanges, CancellationToken cancellationToken)
    =>base.CreateAsync(userSettings, saveChanges, cancellationToken);

    ValueTask<UserSettings?> IUserSettingsRepository.DeleteAsync(UserSettings userSettings, bool saveChanges, CancellationToken cancellationToken)
    =>base.DeleteAsync(userSettings, saveChanges, cancellationToken);

    ValueTask<UserSettings?> IUserSettingsRepository.DeleteByIdAsync(Guid userSettigsId, bool saveChanges, CancellationToken cancellationToken)
    => base.DeleteByIdAsync(userSettigsId, saveChanges, cancellationToken);

    IQueryable<UserSettings> IUserSettingsRepository.Get(Expression<Func<UserSettings, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);

    ValueTask<UserSettings?> IUserSettingsRepository.GetByIdAsync(Guid userSettingsId, bool asNoTracking, CancellationToken cancellationToken)
    =>base.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);

    ValueTask<IList<UserSettings>> IUserSettingsRepository.GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking, CancellationToken cancellationToken)
    =>base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    ValueTask<UserSettings> IUserSettingsRepository.UpdateAsync(UserSettings userSettings, bool saveChanges, CancellationToken cancellationToken)
    {
        var foundSettings = dbContext.UserSettings.SingleOrDefault(dbUserSettings => dbUserSettings.Id == userSettings.Id)
            ?? throw new InvalidOperationException("User settings are not found with this Id!");

        foundSettings.PreferredTheme = userSettings.PreferredTheme;
        foundSettings.PreferredNotificationType = userSettings.PreferredNotificationType;

        return base.UpdateAsync(userSettings, saveChanges, cancellationToken);
    }
}
