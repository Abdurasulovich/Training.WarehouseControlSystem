using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.EntityConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(customer=>customer.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(customer=>customer.LastName).IsRequired().HasMaxLength(50);
        builder.Property(customer => customer.GeneratedId).IsRequired().HasMaxLength(10);
        builder.Property(customer=>customer.PhoneNumber).IsRequired().HasMaxLength(15);
    }
}
