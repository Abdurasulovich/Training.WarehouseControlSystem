using System.Data;
using System.Globalization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Domain.Enums;

namespace Training.WarehouseControlSystem.Infrastructure.Validators;

public class ProductCreateValidator : AbstractValidator<Product>
{
    public ProductCreateValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(product => product.Name)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(255)
                    .WithMessage("Product name is not valid");

                RuleFor(product => product.Quantity)
                    .NotEmpty()
                    .WithMessage("Quantity is not valid");

                RuleFor(product => product.Type)
                    .NotEmpty()
                    .WithMessage("Product type must be entered");

                RuleFor(product => product.Price)
                    .NotEmpty()
                    .WithMessage("Product price must be entered");

                RuleFor(product => product.ProductPlaceId.ToString())
                    .NotEmpty()
                    .MinimumLength(1)
                    .MaximumLength(6)
                    .WithMessage("Product place must be entered");

                RuleFor(product => product.ProductIn)
                    .NotEmpty()
                    .GreaterThanOrEqualTo(DateTimeOffset.Now)
                    .WithMessage("The registration date should not be less than the current time");

                RuleFor(product => product.ProductOut)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTimeOffset.Now)
                    .WithMessage("The product release period should not be less than the current time");

                RuleFor(product => product.UserId)
                    .NotEmpty()
                    .WithMessage("User id is required");

                RuleFor(product => product.CustomerId)
                    .NotEmpty()
                    .WithMessage("Customer id is required");
            });
    }
    
}