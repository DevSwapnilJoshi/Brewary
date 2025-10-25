using EGlossary.Service.Models;
using FluentValidation;

namespace EGlossary.Service.Validator
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(cust => cust.CustomerName).NotEmpty().WithMessage("Customer Name is required.");
            RuleFor(cust => cust.Address).NotEmpty().WithMessage("Customer Address is required.");
            RuleFor(cust => cust.Phone).NotEmpty().WithMessage("Phone is required.");
        }
    }
}