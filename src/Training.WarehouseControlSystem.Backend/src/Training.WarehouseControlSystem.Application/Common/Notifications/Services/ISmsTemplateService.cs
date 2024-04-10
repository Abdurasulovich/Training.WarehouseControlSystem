using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface ISmsTemplateService
{
    IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<SmsTemplate?> GetByTypeAsync(NotificationTemplateType templateType, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}
