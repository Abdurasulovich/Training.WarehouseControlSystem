using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class CustomerRepository(AppDbContext dbContext)
    : EntityRepositoryBase<Customer, AppDbContext>(dbContext), ICustomerRepository
{
    public new IQueryable<Customer?> Get(Expression<Func<Customer, bool>>? predicate = default,
        bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<Customer?> GetByIdAsync(Guid customerId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(customerId, asNoTracking, cancellationToken);

    public new ValueTask<Customer> CreateAsync(Customer customer, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(customer, saveChanges, cancellationToken);

    public new ValueTask<Customer> UpdateAsync(Customer customer, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.UpdateAsync(customer, saveChanges, cancellationToken);

    public new ValueTask<Customer?> DeleteByIdAsync(Guid customerId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(customerId, saveChanges, cancellationToken);
}