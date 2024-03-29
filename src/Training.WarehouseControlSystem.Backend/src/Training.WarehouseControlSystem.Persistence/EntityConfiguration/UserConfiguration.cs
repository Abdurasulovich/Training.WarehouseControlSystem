using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user=>user.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(user=>user.LastName).IsRequired().HasMaxLength(50);
        builder.Property(user => user.username).IsRequired().HasMaxLength(15);
        builder.Property(user => user.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(user=>user.EmailAddress).HasMaxLength(128);
        builder.Property(user=>user.Password).IsRequired().HasMaxLength(128);
        builder.HasIndex(user => user.PhoneNumber).IsUnique();
        builder.HasIndex(user => user.username).IsUnique();
    }
}
