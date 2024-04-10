using Training.WarehouseControlSystem.Domain.Common.Events;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Common.Identity.Events;

public class UserCreatedEvent(User createdUser) : Event
{
    public User CreatedUser { get; set; } = createdUser;
}
