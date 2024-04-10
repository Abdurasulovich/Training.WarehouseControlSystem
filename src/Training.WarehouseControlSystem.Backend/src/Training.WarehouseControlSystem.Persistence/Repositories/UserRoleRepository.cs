using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class UserRoleRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserRole, AppDbContext>(dbContext, cacheBroker), IUserRoleRepository
{
    ValueTask<UserRole> IUserRoleRepository.CreateAsync(UserRole userRole, bool saveChanges, CancellationToken cancellationToken)
    =>base.CreateAsync(userRole, saveChanges, cancellationToken);

    ValueTask<UserRole?> IUserRoleRepository.DeleteAsync(UserRole userRole, bool saveChanges, CancellationToken cancellationToken)
    =>base.DeleteAsync(userRole, saveChanges, cancellationToken);
}
