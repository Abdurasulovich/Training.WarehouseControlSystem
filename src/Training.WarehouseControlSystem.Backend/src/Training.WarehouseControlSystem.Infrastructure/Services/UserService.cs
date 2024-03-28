using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq.Expressions;
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

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = userValidator
            .Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = userValidator
            .Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => userRepository.DeleteByIdAsync(userId, saveChanges, cancellationToken);
}