using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Product
{
    public class ProductVMValidator : AbstractValidator<ProductVM>
    {
        public ProductVMValidator()
        {
            RuleFor(p => p.Title).NotNull().WithMessage(" Boş Olmamalıdır").NotEmpty().WithMessage(" Boş Olmamalıdır");
            RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage(" Boş Olmamalıdır");
            RuleFor(p => p.Count).NotNull().WithMessage(" Boş Olmamalıdır").NotEmpty().WithMessage(" Boş Olmamalıdır").GreaterThanOrEqualTo(0);
            RuleFor(p => p.Price).NotNull().WithMessage(" Boş Olmamalıdır").NotEmpty().WithMessage(" Boş Olmamalıdır").GreaterThanOrEqualTo(0);
            RuleFor(p => p.Photo).NotNull().WithMessage(" Boş Olmamalıdır").NotEmpty().WithMessage(" Boş Olmamalıdır");
        }
    }
}