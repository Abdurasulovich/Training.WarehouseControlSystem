using Training.WarehouseControlSystem.Application.Common.Notifications.Models;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage,
        CancellationToken cancellationToken = default);
}
