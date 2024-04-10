using Training.WarehouseControlSystem.Application.Common.Notifications.Models;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Services;

public interface ISmsRenderingService
{
    ValueTask<string> RenderAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default);
}
