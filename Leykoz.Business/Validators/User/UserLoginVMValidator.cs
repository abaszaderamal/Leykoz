using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.User
{
    public class UserLoginVMValidator : AbstractValidator<UserLoginVM>
    {
        public UserLoginVMValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Boş ola bilməz").NotEmpty().EmailAddress()
                .MaximumLength(60)
                .WithMessage(" Max Uzunluq 60 Simvol Olmalıdır ");
            RuleFor(p => p.Password).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MinimumLength(8)
                .WithMessage(" Min Uzunluq 8 Simvol Olmalıdır ")
                .MaximumLength(100)
                .WithMessage(" Max Uzunluq 100 Simvol Olmalıdır ");
        }
    }
}