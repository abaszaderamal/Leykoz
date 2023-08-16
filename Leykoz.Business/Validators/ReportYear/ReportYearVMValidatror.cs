using FluentValidation;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Validators.ReportYear
{
    public class ReportYearVMValidatror : AbstractValidator<ReportYearVM>
    {
        public ReportYearVMValidatror()
        {
            RuleFor(p => p.HeadTitle).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
            RuleFor(p => p.Title).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
            RuleFor(p => p.Year).NotNull().WithMessage("Boş ola bilməz").NotEmpty();
        }
    }
}