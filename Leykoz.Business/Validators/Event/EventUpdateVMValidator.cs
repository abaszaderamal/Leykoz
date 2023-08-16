using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Event
{
    public class EventUpdateVMValidator:AbstractValidator<EventUpdateVM>
    {
        public EventUpdateVMValidator()
        {
            RuleFor(p => p.Title).NotNull().WithMessage("Boş ola bilməz").NotEmpty()
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
            RuleFor(p => p.Content).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
        
    }
}