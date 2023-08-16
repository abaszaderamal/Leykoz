using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Slide
{
    public class SlidePostVMValidator : AbstractValidator<SlidePostVM>
    {
        public SlidePostVMValidator()
        {
            RuleFor(p => p.FormFiles).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}