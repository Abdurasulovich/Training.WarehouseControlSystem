using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.StorageFiles;

public interface IStorageFileService
{
    IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>>? predicate = default,
        bool asNoTracking = false);
}
