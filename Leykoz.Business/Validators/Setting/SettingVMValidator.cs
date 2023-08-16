using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Setting
{
    public class SettingVMValidator: AbstractValidator<SettingVM>
    {
        public SettingVMValidator()
        {
            RuleFor(p => p.Value).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
        }
    }
}