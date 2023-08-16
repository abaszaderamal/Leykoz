using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.News
{
    public class NewsPutVMValidator : AbstractValidator<NewsPutVM>
    {
        public NewsPutVMValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Title).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Contetnt).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}