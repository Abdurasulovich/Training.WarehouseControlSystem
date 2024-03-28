using FluentValidation;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Infrastructure.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(user => user.EmailAddress)
                    .MinimumLength(5)
                    .MaximumLength(128);

                RuleFor(user => user.FirstName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(50)
                    .WithMessage("First name is not valid");

                RuleFor(user => user.LastName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(50)
                    .WithMessage("Last name is not valid");

                RuleFor(user => user.Password)
                    .NotEmpty()
                    .MinimumLength(8)
                    .MaximumLength(128);

                RuleFor(user => user.username)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(15)
                    .WithMessage("'username' is not valid");

                RuleFor(user => user.PhoneNumber)
                    .NotEmpty()
                    .MinimumLength(13)
                    .MaximumLength(15)
                    .WithMessage("Phone number is not valid");
            });
    }
}