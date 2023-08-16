using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.User
{
    public class ResetPasswordVMValidator: AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordVMValidator()
        {
            RuleFor(p => p.Password).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.ConfirmPassword).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(90)
                .WithMessage(" Max Uzunluq 90 Simvol Olmalıdır ")
                .Equal(p => p.Password).WithMessage("Yeni parol ilə təsdiq parolu uyğun gəlmir.");
        }
    }
}