using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Training.WarehouseControlSystem.Domain.Brokers;
using Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;
using Training.WarehouseControlSystem.Domain.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Interceptors
{
    internal class UpdateAuditableInterceptor(IRequestUserContextProvider userContextProvider)
        : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var auditableEntries =
                eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();

            var creationAuditableEntries = 
                eventData.Context!.ChangeTracker.Entries<ICreationAuditableEntity>().ToList();

            var modificationAuditableEntries =
                eventData.Context!.ChangeTracker.Entries<IModificationAuditableEntity>().ToList();

            auditableEntries.ForEach(entry =>
            {
                if (entry.State == EntityState.Modified)
                    entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTimeOffset.UtcNow;

                if (entry.State == EntityState.Added)
                    entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTimeOffset.UtcNow;
            });

            creationAuditableEntries.ForEach(entry =>
            {
                if (entry.State == EntityState.Added)
                    entry.Property(nameof(ICreationAuditableEntity.CreatedByUserId)).CurrentValue
                    = userContextProvider.GetUserId();
            });

            modificationAuditableEntries.ForEach(entry =>
            {
                if (entry.State == EntityState.Modified)
                    entry.Property(nameof(IModificationAuditableEntity.ModifiedByUserId)).CurrentValue
                    = userContextProvider.GetUserId();
            });

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
