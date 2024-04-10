using Training.WarehouseControlSystem.Application.Common.Notifications.Models;

namespace Training.WarehouseControlSystem.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}
