using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.InfoSlide
{
    public class InfoSlidePostVMValidator : AbstractValidator<InfoSlidePostVM>
    {
        public InfoSlidePostVMValidator()
        {
            RuleFor(p => p.FirstName).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.LastName).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.Title).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");   
            RuleFor(p => p.MsgTitleContetnt).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Contetnt).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(500)
                .WithMessage(" Max Uzunluq 500 Simvol Olmalıdır ");
            RuleFor(p => p.MsgContetnt).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
            RuleFor(p => p.ImageFile).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}