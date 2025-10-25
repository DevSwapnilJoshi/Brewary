using EGlossary.Service.Models;
using FluentValidation;

namespace EGlossary.Service.Validator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(user => user.ProductName).NotEmpty().WithMessage("Product Name is required.");
            RuleFor(user => user.CategoryId).NotNull().WithMessage("CategoryId is required.");
        }
    }
}