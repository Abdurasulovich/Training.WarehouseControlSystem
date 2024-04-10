using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class StorageFileRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<StorageFile, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    IStorageFileRepository
{
    IQueryable<StorageFile> IStorageFileRepository.Get(Expression<Func<StorageFile, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);
}
