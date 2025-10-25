using EGlossary.Service.Models;
using FluentValidation;

namespace EGlossary.Service.Validator
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(o => o.VoucherNumber).NotEmpty().WithMessage("VoucherNumber is required.");

            RuleFor(o => o.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(o => o.Product).NotNull().WithMessage("Atleast one Product must be added");
        }
    }
}