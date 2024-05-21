using FluentValidation;
using REPR_API.Models;

namespace REPR_API.Validators
{
    public class ProductValiator : AbstractValidator<Product>
    {
        public ProductValiator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p=>p.Manufacturer).NotEmpty();
            RuleFor(p=>p.Price).GreaterThan(0);
            RuleFor(p=>p.CategoryUniqueId).NotNull();
            RuleFor(p => p.CategoryUniqueId).GreaterThan(0);
        }
    }
}
