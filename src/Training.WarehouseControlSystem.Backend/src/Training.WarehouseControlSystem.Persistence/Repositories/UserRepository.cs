using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class UserRepository(AppDbContext dbContext)
    : EntityRepositoryBase<User, AppDbContext>(dbContext) , IUserRepository
{
    public new IQueryable<User?> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.UpdateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(userId, saveChanges, cancellationToken);
}
