﻿using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

public interface ICustomerRepository
{
    IQueryable<Customer?> Get(Expression<Func<Customer, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Customer?> GetByIdAsync(Guid customerId, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    ValueTask<Customer> CreateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Customer> UpdateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Customer?> DeleteByIdAsync(Guid customerId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
