using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.User
{
    public class ForgotPasswordVMValidator:AbstractValidator<ForgotPasswordVM>
    {
        public ForgotPasswordVMValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .EmailAddress()
                .WithMessage("Istifadəçi tapılmadı.")
                .MaximumLength(60)
                .WithMessage(" Max Uzunluq 60 Simvol Olmalıdır ");
        }
    }
}