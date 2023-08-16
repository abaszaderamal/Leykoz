using FluentValidation;

namespace Leykoz.Business.Validators.Setting
{
    public class otherVMValidator : AbstractValidator<otherVM>
    {
        public otherVMValidator()
        {
            RuleFor(p => p.Address).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Phone).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.FooterTxt).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
        }
    }
}