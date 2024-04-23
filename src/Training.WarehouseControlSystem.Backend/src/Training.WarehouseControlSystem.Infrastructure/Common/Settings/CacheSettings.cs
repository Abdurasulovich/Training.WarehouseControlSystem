namespace Training.WarehouseControlSystem.Infrastructure.Common.Settings;

public class CacheSettings
{
    public uint AbsoluteExpirationInSeconds { get; set; }
    
    public uint SlidingExpirationInSeconds { get; set; }
}