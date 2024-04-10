using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

public interface IStorageFileRepository
{
    IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>>? predicate = default,
        bool asNoTracking = false);
}
