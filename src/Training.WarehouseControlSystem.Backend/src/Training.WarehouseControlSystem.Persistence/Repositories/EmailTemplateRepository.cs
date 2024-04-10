using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class EmailTemplateRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<EmailTemplate, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    IEmailTemplateRepository
{
    IQueryable<EmailTemplate> IEmailTemplateRepository.Get(Expression<Func<EmailTemplate, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);

    ValueTask<EmailTemplate> IEmailTemplateRepository.CreateAsync(EmailTemplate emailTemplate, bool saveChanges, CancellationToken cancellationToken)
    => base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
}
