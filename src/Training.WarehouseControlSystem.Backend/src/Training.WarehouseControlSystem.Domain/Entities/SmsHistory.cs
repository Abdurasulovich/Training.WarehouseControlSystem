using Type = Training.WarehouseControlSystem.Domain.Enums.NotificationType;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory() => Type = Type.Sms;
    
    public string SenderPhoneNumber { get; set; }
    
    public string ReceiverPhoneNumber { get; set; }
    
    public SmsTemplate Template { get; set; }
}
