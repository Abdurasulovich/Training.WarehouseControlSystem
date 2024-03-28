using FluentValidation;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Infrastructure.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(customer => customer.FirstName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(50)
                    .WithMessage("First name is not valid");

                RuleFor(customer => customer.LastName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(50)
                    .WithMessage("Last name is not valid");

                RuleFor(customer => customer.PhoneNumber)
                    .NotEmpty()
                    .MinimumLength(13)
                    .MaximumLength(15)
                    .WithMessage("Phone number is not valid");

                RuleFor(customer => customer.GeneratedId.ToString())
                    .NotEmpty()
                    .MinimumLength(10)
                    .MaximumLength(10);

                RuleFor(customer => customer.Products)
                    .NotEmpty();
            });
    }
}