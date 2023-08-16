using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators
{
    public class ReportAmountVMValidator : AbstractValidator<ReportAmountVM>
    {
        public ReportAmountVMValidator()
        {
            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("Boş ola bilməz")
                .NotEmpty()
                .GreaterThanOrEqualTo(0.1);
        }
    }
}