using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class SmsTemplateRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<SmsTemplate, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    ISmsTemplateRepository
{
    IQueryable<SmsTemplate> ISmsTemplateRepository.Get(Expression<Func<SmsTemplate, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);

    ValueTask<SmsTemplate> ISmsTemplateRepository.CreateAsync(SmsTemplate smsTemplate, bool saveChanges, CancellationToken cancellationToken)
    =>base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
}
