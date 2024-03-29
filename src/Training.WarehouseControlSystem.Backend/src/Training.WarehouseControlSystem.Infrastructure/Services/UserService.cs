using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;
using Training.WarehouseControlSystem.Infrastructure.Validators;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Infrastructure.Services;

public class UserService(IUserRepository userRepository, UserValidator userValidator) : IUserService
{
    public IQueryable<User?> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
        => userRepository.Get(predicate, asNoTracking);

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => await userRepository.Get(asNoTracking: asNoTracking)
            .FirstOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = userValidator
            .Validate(user);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        if (user.EmailAddress != "" &&
            await userRepository.Get(asNoTracking: false)
                    .FirstOrDefaultAsync(email => email.EmailAddress == user.EmailAddress)
                is not null)
            throw new InvalidOperationException("This email address already exist.");
        
            user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        return await userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = userValidator
            .Validate(user);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        if (user.EmailAddress != "" &&
            await userRepository.Get(asNoTracking: false)
                    .FirstOrDefaultAsync(email => email.EmailAddress == user.EmailAddress)
                is not null)
            throw new InvalidOperationException("This email address already exist.");
        
        var users = await Get(asNoTracking: false)
            .FirstOrDefaultAsync(u => u.Id == user.Id);
        
        user.CreatedAt = users.CreatedAt;
        user.UpdatedAt = DateTime.UtcNow;

        var result =  await userRepository.UpdateAsync(user, saveChanges, cancellationToken);
        return result;
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => userRepository.DeleteByIdAsync(userId, saveChanges, cancellationToken);
}