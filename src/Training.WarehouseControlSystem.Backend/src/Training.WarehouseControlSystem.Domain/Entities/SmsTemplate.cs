using Training.WarehouseControlSystem.Domain.Enums;
using Type = Training.WarehouseControlSystem.Domain.Enums.NotificationType;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate() => Type = Type.Sms;
}