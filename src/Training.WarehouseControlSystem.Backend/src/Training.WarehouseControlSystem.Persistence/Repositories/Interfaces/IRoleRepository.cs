using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role>  Get(Expression<Func<Role, bool>>? predicate = default,
        bool asNoTracking = false);
}
