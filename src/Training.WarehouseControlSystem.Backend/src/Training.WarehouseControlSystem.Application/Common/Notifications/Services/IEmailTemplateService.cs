using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface IEmailTemplateService
{
    IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<EmailTemplate?> GetByTypeAsync(NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate,
        bool saveChanges = true, 
        CancellationToken cancellationToken = default);
}
