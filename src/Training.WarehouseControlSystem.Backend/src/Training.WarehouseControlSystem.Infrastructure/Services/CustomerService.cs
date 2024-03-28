using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Infrastructure.Validators;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Infrastructure.Services;

public class CustomerService(ICustomerRepository customerRepository, CustomerValidator customerValidator)
    : ICustomerService
{
    public IQueryable<Customer?> Get(Expression<Func<Customer, bool>>? predicate = default, bool asNoTracking = false)
        => customerRepository.Get(predicate, asNoTracking);

    public ValueTask<Customer?> GetByIdAsync(Guid customerId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => customerRepository.GetByIdAsync(customerId, asNoTracking, cancellationToken);

    public async ValueTask<Customer?> GetBySpecialIdAsync(int specialId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => await customerRepository.Get(asNoTracking: asNoTracking)
            .FirstOrDefaultAsync(customer => customer.GeneratedId == specialId, cancellationToken: cancellationToken);

    public ValueTask<Customer> CreateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = customerValidator.Validate(customer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return customerRepository.CreateAsync(customer, saveChanges, cancellationToken);
    }

    public ValueTask<Customer> UpdateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = customerValidator.Validate(customer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return customerRepository.UpdateAsync(customer, saveChanges, cancellationToken);
    }

    public ValueTask<Customer?> DeleteByIdAsync(Guid customerId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => customerRepository.DeleteByIdAsync(customerId, saveChanges, cancellationToken);
}