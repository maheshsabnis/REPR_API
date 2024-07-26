using FluentValidation;
using REPR_API.Models;

namespace REPR_API.Validators
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.CategoryName).NotEmpty();
            RuleFor(p => p.BasePrice).GreaterThan(0);
        }
    }
}
