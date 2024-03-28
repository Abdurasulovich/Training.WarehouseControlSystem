using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Application.Services;

public interface IProductService
{
    IQueryable<Product?> Get(Expression<Func<Product, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Product?> GetByIdAsync(Guid productId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<IList<Product>> GetByRegisteredUserIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Product> CreateAsync(Product product, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Product> UpdateAsync(Product product, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Product?> DeleteByIdAsync(Guid productId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
