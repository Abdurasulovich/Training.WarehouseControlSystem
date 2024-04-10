using Training.WarehouseControlSystem.Domain.Common.Entities.Interfaces;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class UserRole : IEntity
{
    public UserRole()
    {
        
    }
    public UserRole(Guid userId, Guid roleId) => (UserId, RoleId) = (userId, roleId);


    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
    public Guid Id { get; set; }

}
