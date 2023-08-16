using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.User
{
    public class UserPostVMValidator : AbstractValidator<UserPostVM>
    {
        public UserPostVMValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .EmailAddress()
                .MaximumLength(60)
                .WithMessage(" Max Uzunluq 60 Simvol Olmalıdır ");
            RuleFor(p => p.UserName).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.Password).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
            RuleFor(p => p.ConfirmPassword).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ")
                .Equal(p => p.Password).WithMessage("Yeni parol ilə təsdiq parolu uyğun gəlmir.");
        }
    }
}