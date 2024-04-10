using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface ISmsHistoryService
{
    IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
