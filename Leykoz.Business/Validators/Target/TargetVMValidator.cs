using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Target
{
    public class TargetVMValidator : AbstractValidator<TargetVM>
    {
        public TargetVMValidator()
        {
            RuleFor(p => p.Content).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
        }
    }
}