using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class SmsHistoryRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<SmsHistory, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    ISmsHistoryRespository
{
    ValueTask<SmsHistory> ISmsHistoryRespository.CreateAsync(SmsHistory smsHistory, bool saveChanges, CancellationToken cancellationToken)
    =>base.CreateAsync(smsHistory, saveChanges, cancellationToken);

    IQueryable<SmsHistory> ISmsHistoryRespository.Get(Expression<Func<SmsHistory, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);
}
