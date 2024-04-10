using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Brokers;

public interface IRequestUserContextProvider
{
    Guid GetUserId();

    RoleType GetUserRole();

    string? GetAccessToken();
}
