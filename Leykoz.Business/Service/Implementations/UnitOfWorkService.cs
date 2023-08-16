using Leykoz.Business.Service.Interfaces;
using Leykoz.Core.Abstract;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.Concrete.Repositories;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Leykoz.Business.Service.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;


        // private readonly UserManager<ApplicationUser> _userManager;
        // private readonly SignInManager<ApplicationUser> _signInManager;
        // private readonly RoleManager<IdentityRole> _roleManager;


        //services

        private ISaviorService _saviorService;
        private ISlideService _slideService;
        private ISiteSettingService _siteSettingService;
        private ITargetService _targetService;
        private IEventService _eventService;
        private InfoSlideService _infoSlideService;
        private IReportService _reportService;
        private IProductService _productService;
        private INewsService _newsService;
        private IDashBoardService _dashBoardService;
        private IReportYearService _reportYearService;
        private IReportAmountService _reportAmountService;


        private readonly IHttpContextAccessor _httpContextAccessor;
        // private IUserService _userService;

        public UnitOfWorkService(IUnitOfWork unitOfWork, IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            // _userManager = userManager;
            // _signInManager = signInManager;
            // _roleManager = roleManager;
        }

        public ISaviorService SaviorService => _saviorService ??= new SaviorService(_unitOfWork);

        public ISiteSettingService SiteSettingService => _siteSettingService ??= new SiteSettingService(_unitOfWork);
        public ISlideService SlideService => _slideService ??= new SlideService(_unitOfWork, _env);

        public ITargetService TargetService => _targetService ??= new TargetService(_unitOfWork);

        public IEventService EventService => _eventService ??= new EventService(_unitOfWork);
        public IReportAmountService ReportAmountService => _reportAmountService ?? new ReportAmountService(_unitOfWork);
        public IReportService ReportService => _reportService ??= new ReportService(_unitOfWork);

        public IInfoSlideService InfoSlideService =>
            _infoSlideService ??= new InfoSlideService(_unitOfWork, _env, _httpContextAccessor);

        public IProductService ProductService =>
            _productService ??= new ProductService(_unitOfWork, _env, _httpContextAccessor);

        public INewsService NewsService => _newsService ??= new NewsService(_unitOfWork, _env);
        public IDashBoardService DashBoardService => _dashBoardService ??= new DashBoardService(_unitOfWork);

        public IReportYearService ReportYearService => _reportYearService ??= new ReportYearService(_unitOfWork);


        // public IUserService UserService => _userService ??= new UserService(_userManager, _signInManager, _roleManager);
    }
}