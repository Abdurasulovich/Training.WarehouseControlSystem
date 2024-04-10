using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(50);
        builder.Property(user => user.username).IsRequired().HasMaxLength(15);
        builder.HasIndex(user => user.EmailAddress).IsUnique();
        builder.Property(user => user.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.HasIndex(user => user.PhoneNumber).IsUnique();
        builder.HasIndex(user => user.username).IsUnique();

        builder.OwnsOne(user => user.UserCredentials, userCredentialConfiguration =>
        {
            userCredentialConfiguration.Property(userCredentials => userCredentials.PasswordHash).IsRequired()
            .HasMaxLength(128);
        });

        builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity<UserRole>(userRole =>
            {
                userRole.HasKey(relation => new { relation.UserId, relation.RoleId });
                userRole.ToTable($"{nameof(UserRole)}s");
            });

    }
}
