using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class RoleRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Role, AppDbContext>(dbContext, cacheBroker), IRoleRepository
{
    IQueryable<Role> IRoleRepository.Get(Expression<Func<Role, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);
}
