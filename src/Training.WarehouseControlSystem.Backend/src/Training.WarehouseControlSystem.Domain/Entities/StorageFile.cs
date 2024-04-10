using Training.WarehouseControlSystem.Domain.Common.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class StorageFile : Entity
{
    public string FileName { get; set; } = default!;

    public StorageFileType Type { get; set; }
}
