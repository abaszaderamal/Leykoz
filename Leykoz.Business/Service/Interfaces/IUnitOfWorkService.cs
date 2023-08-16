using Leykoz.Business.Service.Implementations;
using Leykoz.Core.Abstract.Repositories;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        public ISaviorService SaviorService { get; }
        public ISiteSettingService SiteSettingService { get; }
        public ISlideService SlideService { get; }
        public ITargetService TargetService { get; }
        public IEventService EventService { get; }
        public IInfoSlideService InfoSlideService { get; }
        public IReportAmountService ReportAmountService { get; }
        public IReportService ReportService { get; }
        public IProductService ProductService { get; }
        public INewsService NewsService { get; }
        public IDashBoardService DashBoardService { get; }
        public IReportYearService ReportYearService { get; }
         // public IUserService UserService { get; }
        
    }
}