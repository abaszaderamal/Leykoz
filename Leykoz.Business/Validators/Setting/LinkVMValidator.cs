using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Setting
{
    public class LinkVMValidator:AbstractValidator<LinkVM>
    {
        public LinkVMValidator()
        {
            RuleFor(p => p.Value1).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Value2).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Email).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Fb).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Insta).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Linkedin).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Twit).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.Yt).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
            RuleFor(p => p.SiteYtVideo).NotEmpty().WithMessage("Boş ola bilməz").NotNull();
        }
    }
}