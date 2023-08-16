using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Event
{
    public class EventVMValidator : AbstractValidator<EventVM>
    {
        public EventVMValidator()
        {
            RuleFor(p => p.Content).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
            RuleFor(p => p.EventDate).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}