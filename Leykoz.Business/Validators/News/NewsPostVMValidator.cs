using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.News
{
    public class NewsPostVMValidator : AbstractValidator<NewsPostVM>
    {
        public NewsPostVMValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Title).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Contetnt).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
            RuleFor(p => p.Image).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}