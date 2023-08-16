using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Setting
{
    public class CardSettingVMValidator : AbstractValidator<CardSettingVM>
    {
        public CardSettingVMValidator()
        {
            RuleFor(p => p.Value1).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Value2).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Value3).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
        }
    }
}