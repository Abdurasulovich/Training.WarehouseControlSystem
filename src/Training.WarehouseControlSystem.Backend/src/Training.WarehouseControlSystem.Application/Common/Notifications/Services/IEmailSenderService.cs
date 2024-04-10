using Training.WarehouseControlSystem.Application.Common.Notifications.Models;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
