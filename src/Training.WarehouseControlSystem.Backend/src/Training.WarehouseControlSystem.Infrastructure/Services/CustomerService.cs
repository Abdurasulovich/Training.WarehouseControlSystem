using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Infrastructure.Common;
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

    public async ValueTask<Customer> CreateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = customerValidator.Validate(customer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        List<int> customerNums = new();
        var customerGeneratedNumbers = Get(asNoTracking: false);

        foreach (var cust in customerGeneratedNumbers)
            customerNums.Add(cust.GeneratedId);
        
        customer.GeneratedId =  CustomerRandomGenericNumber.GenerateNumber(customerNums);
        customer.CreatedAt = DateTime.UtcNow;
        customer.UpdatedAt = DateTime.UtcNow;

        return await customerRepository.CreateAsync(customer, saveChanges, cancellationToken);
    }

    public async ValueTask<Customer?> UpdateAsync(Customer customer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = await customerValidator.ValidateAsync(customer);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var foundCustomer = await Get(asNoTracking: false)
            .FirstOrDefaultAsync(c => c.Id == customer.Id, cancellationToken) ??
                        throw new InvalidOperationException("Customer with this id not found.");
        
        customer.GeneratedId = foundCustomer.GeneratedId;
        customer.CreatedAt = foundCustomer.CreatedAt;
        customer.UpdatedAt = DateTime.UtcNow;
        if (customer.Description.Length == 0 & foundCustomer.Description.Length != 0)
            customer.Description = foundCustomer.Description;
        
        return await customerRepository.UpdateAsync(customer, saveChanges, cancellationToken);
    }

    public async ValueTask<Customer?> DeleteByIdAsync(Guid customerId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await customerRepository.DeleteByIdAsync(customerId, saveChanges, cancellationToken)
           ?? throw new InvalidOperationException("Customer with this id not found.");
}