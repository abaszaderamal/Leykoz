using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.User
{
    public class ChangePasswordVMValidator:AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordVMValidator()
        {
            RuleFor(p => p.CurrentPassword).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.NewPassword).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.ConfirmPassword).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ")
                .Equal(p => p.NewPassword).WithMessage("Yeni parol ilə təsdiq parolu uyğun gəlmir.");
        }
    }
}