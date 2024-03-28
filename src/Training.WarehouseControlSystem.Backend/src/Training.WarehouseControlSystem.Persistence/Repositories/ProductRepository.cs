using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class ProductRepository(AppDbContext dbContext)
    : EntityRepositoryBase<Product, AppDbContext>(dbContext), IProductRepository
{
    public new IQueryable<Product?> Get(Expression<Func<Product, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<Product?> GetByIdAsync(Guid productId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(productId, asNoTracking, cancellationToken);

    public new ValueTask<Product> CreateAsync(Product product, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(product, saveChanges, cancellationToken);

    public new ValueTask<Product> UpdateAsync(Product product, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.UpdateAsync(product, saveChanges, cancellationToken);

    public new ValueTask<Product?> DeleteByIdAsync(Guid productId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(productId, saveChanges, cancellationToken);
}