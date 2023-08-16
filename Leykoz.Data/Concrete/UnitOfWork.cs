using System.Threading.Tasks;
using Leykoz.Core.Abstract;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Data.Concrete.Repositories;
using Leykoz.Data.DAL;

namespace Leykoz.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISilideRepository _silideRepository;
        private ISiteSettingRepository _siteSettingRepository;
        private ISaviorRepository _saviorRepository;
        private ITargetRepository _targetRepository;
        private IEventRepository _eventRepository;
        private IInfoSlideRepository _infoSlideRepository;
        private INewsRepository _newsRepository;
        private IReportRepository _reportRepository;
        private IProductRepository _productRepository;
        private IReportYearRepository _reportYearRepository;
        private IReportAmountRepository _reportAmountRepository;

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public ISilideRepository SilideRepository =>
            _silideRepository ??= new SlideRepository(_context);

        public ISiteSettingRepository SiteSettingRepository =>
            _siteSettingRepository ??= new SiteSettingRepository(_context);

        public ISaviorRepository SaviorRepository => _saviorRepository
            ??= new SaviorRepository(_context);

        public ITargetRepository TargetRepository => _targetRepository
            ??= new TargetRepository(_context);

        public IEventRepository EventRepository => _eventRepository
            ??= new EventRepository(_context);

        public IInfoSlideRepository InfoSlideRepository => _infoSlideRepository
            ??= new InfoSlideRepository(_context);

        public INewsRepository NewsRepository => _newsRepository
            ??= new NewsRepository(_context);

        public IReportRepository ReportRepository => _reportRepository
            ??= new ReportRepository(_context);

        public IProductRepository ProductRepository => _productRepository
            ??= new ProductRepository(_context);

        public IReportYearRepository ReportYearRepository =>
            _reportYearRepository ??= new ReportYearRepository(_context);

        public IReportAmountRepository ReportAmountRepository =>
            _reportAmountRepository ??= new ReportAmountRepository(_context);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}