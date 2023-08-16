using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators
{
    public class ReportVMValidator : AbstractValidator<ReportVM>
    {
        public ReportVMValidator()
        {
            // RuleFor(p => p.Name).NotEmpty().WithMessage("Boş ola bilməz").NotEmpty().GreaterThanOrEqualTo((decimal)0.1);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(p => p.SurName)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .NotEmpty().WithMessage("Boş ola bilməz");
        }
    }
}