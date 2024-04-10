using Newtonsoft.Json;

namespace Training.WarehouseControlSystem.Application.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}
