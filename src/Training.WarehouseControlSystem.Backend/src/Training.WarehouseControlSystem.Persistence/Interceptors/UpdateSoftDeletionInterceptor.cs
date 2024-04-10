using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Training.WarehouseControlSystem.Domain.Brokers;
using Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;
using Training.WarehouseControlSystem.Domain.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Interceptors;

public class UpdateSoftDeletionInterceptor(IRequestUserContextProvider userContextProvider)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var softDeletedEntries =
            eventData.Context!.ChangeTracker.Entries<ISoftDeleteEntity>().ToList();

        var deletionAuditableEntries = 
            eventData.Context!.ChangeTracker.Entries<IDeletionAuditableEntity>().ToList();

        deletionAuditableEntries.ForEach(entry =>
        {

            if (entry.State != EntityState.Deleted) return;

            entry.State = EntityState.Modified;

            entry.Property(nameof(IDeletionAuditableEntity.DeletedByUserId)).CurrentValue
                = userContextProvider.GetUserId();
        });

        softDeletedEntries.ForEach(entry =>
        {
            if (entry.State != EntityState.Deleted) return;

            entry.State = EntityState.Modified;

            var ownedTypes = entry.References.Where(entity => entity.Metadata.TargetEntityType.IsOwned()).ToList();
            ownedTypes.ForEach(entity => entity.TargetEntry.State = EntityState.Modified);

            entry.Property(nameof(ISoftDeleteEntity.IsDeleted)).CurrentValue = true;
            entry.Property(nameof(ISoftDeleteEntity.DeletedTime)).CurrentValue = DateTimeOffset.UtcNow;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
