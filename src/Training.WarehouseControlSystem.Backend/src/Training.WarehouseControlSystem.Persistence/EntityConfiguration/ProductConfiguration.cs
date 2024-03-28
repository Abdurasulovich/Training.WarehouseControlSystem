using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.Name).IsRequired().HasMaxLength(255);
        builder.Property(product=>product.Price).IsRequired();
        builder.Property(product=>product.Quantity).IsRequired();
        builder.Property(product => product.Type).IsRequired();
        builder.Property(product=>product.ProductPlaceId).IsRequired();
        builder.Property(product=>product.ProductIn).IsRequired();
        builder.Property(product=>product.ProductOut).IsRequired();

        builder
            .HasOne(product => product.User)
            .WithMany(user=>user.Products)
            .HasForeignKey(product => product.UserId);

        builder
            .HasOne(product => product.Customer)
            .WithMany(customer=>customer.Products)
            .HasForeignKey(product => product.CustomerId);
    }

}
