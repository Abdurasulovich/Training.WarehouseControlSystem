using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class EmailHistoryRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<EmailHistory, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    IEmailHistoryRepository
{
    IQueryable<EmailHistory> IEmailHistoryRepository.Get(
        Expression<Func<EmailHistory, bool>>? predicate, bool asNoTracking)
    => base.Get(predicate, asNoTracking);

    ValueTask<EmailHistory> IEmailHistoryRepository.CreateAsync(
        EmailHistory emailHistory, bool saveChanges, CancellationToken cancellationToken)
    => base.CreateAsync(emailHistory, saveChanges, cancellationToken);
}
