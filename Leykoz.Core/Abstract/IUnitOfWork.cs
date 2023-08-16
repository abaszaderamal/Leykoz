using System.Threading.Tasks;
using Leykoz.Core.Abstract.Repositories;

namespace Leykoz.Core.Abstract
{
    public interface IUnitOfWork
    {
        ISilideRepository SilideRepository { get; }
        ISiteSettingRepository SiteSettingRepository { get; }
        ISaviorRepository SaviorRepository { get; }
        ITargetRepository TargetRepository { get; }
        IEventRepository EventRepository { get; }
        IInfoSlideRepository InfoSlideRepository { get; }
        INewsRepository NewsRepository { get; }
        IReportRepository ReportRepository { get; }
        IProductRepository ProductRepository { get; }
        IReportYearRepository ReportYearRepository { get; }
        IReportAmountRepository ReportAmountRepository { get; }
        Task SaveAsync();
    }
}