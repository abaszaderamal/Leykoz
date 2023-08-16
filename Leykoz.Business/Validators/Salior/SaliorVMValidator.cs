using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.Salior
{
    public class SaliorVMValidator : AbstractValidator<SaviorVM>
    {
        public SaliorVMValidator()
        {
            RuleFor(p => p.FullName)
                .NotNull()
                .WithMessage(" Boş Olmamalıdır")
                .NotEmpty()
                .WithMessage(" Boş Olmamalıdır")
                .MaximumLength(160)
                .WithMessage(" Max Uzunluq 160 Simvol Olmalıdır ");
            RuleFor(p => p.Phone)
                .NotNull()
                .WithMessage(" Boş Olmamalıdır")
                .NotEmpty()
                .WithMessage(" Boş Olmamalıdır")
                .Matches(@"^(\+|\d)[0-9]{8,16}$")
                .WithMessage(" Düzgün Format Daxil Edilməyib")
                .MaximumLength(50)
                .WithMessage(" Max Uzunluq 50 Simvol Olmalıdır ");
            RuleFor(p => p.Email)
                .NotNull()
                .WithMessage(" Boş Olmamalıdır")
                .NotEmpty()
                .WithMessage(" Boş Olmamalıdır")
                .EmailAddress()
                .MaximumLength(200);
            RuleFor(p => p.ApplyType)
                .NotNull()
                .WithMessage(" Boş Olmamalıdır")
                .NotEmpty()
                .WithMessage(" Boş Olmamalıdır")
                .MaximumLength(200)
                .WithMessage(" Max Uzunluq 200 Simvol Olmalıdır ");
          
            RuleFor(p => p.ApplyContent)
                .NotNull()
                .WithMessage(" Boş Olmamalıdır")
                .NotEmpty()
                .WithMessage(" Boş Olmamalıdır")
                .MaximumLength(500)
                .WithMessage(" Max Uzunluq 500 Simvol Olmalıdır ");
        
        }
    }
}