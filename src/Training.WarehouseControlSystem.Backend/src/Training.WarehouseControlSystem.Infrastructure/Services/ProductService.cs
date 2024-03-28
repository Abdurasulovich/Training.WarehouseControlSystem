
using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Infrastructure.Validators;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Infrastructure.Services;

public class ProductService(
    IProductRepository productRepository, 
    ProductCreateValidator productCreateValidator,
    ProductUpdateValidator productUpdateValidator) 
    : IProductService
{
    public IQueryable<Product?> Get(Expression<Func<Product, bool>>? predicate = default, bool asNoTracking = false)
        => productRepository.Get(predicate, asNoTracking);

    public ValueTask<Product?> GetByIdAsync(Guid productId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => productRepository.GetByIdAsync(productId, asNoTracking, cancellationToken);

    public async ValueTask<IList<Product>> GetByRegisteredUserIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => await productRepository.Get(asNoTracking: asNoTracking)
            .Where(product => product.UserId == userId)
            .ToListAsync(cancellationToken: cancellationToken);
    

    public ValueTask<Product> CreateAsync(Product product, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = productCreateValidator.Validate(product);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        return productRepository.CreateAsync(product, saveChanges, cancellationToken);
    }

    public ValueTask<Product> UpdateAsync(Product product, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = productUpdateValidator.Validate(product);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return productRepository.UpdateAsync(product, saveChanges, cancellationToken);
    }

    public ValueTask<Product?> DeleteByIdAsync(Guid productId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => productRepository.DeleteByIdAsync(productId, saveChanges, cancellationToken);
}