using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;


namespace Leykoz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HomeController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
           /*last mssql*///
            // EmailHelper.SendEmail("hcavid386@gmail.com", "salamlar", "salam nigar xanim");
            // _unitOfWorkService.EmailService.SendEmail("tu201906017@code.edu.az", "salamlar", "salam nigar xanim");
            // Stopwatch r = new Stopwatch();
            // r.Start();
            ViewBag.slides = await _unitOfWorkService.SlideService.GetAllAsync();
            // r.Stop();
            // Console.WriteLine("Slide"+r.ElapsedMilliseconds);
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();
            ViewBag.Targets = await _unitOfWorkService.TargetService.GetAllAcync();
            ViewBag.Events = await _unitOfWorkService.EventService.GetAllAsync();
            // ViewBag.YearReports = await _unitOfWorkService.ReportYearService.GetAllAsync(); 
            // Stopwatch c = new Stopwatch();
            // c.Start();
            ViewBag.YearReports = await _unitOfWorkService.ReportYearService.GetAllReportYearWithAllCount();
            // c.Stop();
            // Console.WriteLine("reports"+c.ElapsedMilliseconds);
            ViewBag.News = await _unitOfWorkService.NewsService.GetLastNews(9);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SaviorVM saviorVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.SaviorService.CreateAsync(saviorVm);
                return RedirectToAction(nameof(Index));
            }

            
            ViewBag.slides = await _unitOfWorkService.SlideService.GetAllAsync();
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();
            ViewBag.Targets = await _unitOfWorkService.TargetService.GetAllAcync();
            ViewBag.Events = await _unitOfWorkService.EventService.GetAllAsync();
            ViewBag.News = await _unitOfWorkService.NewsService.GetLastNews(9);
            ViewBag.YearReports = await _unitOfWorkService.ReportYearService.GetAllReportYearWithAllCount();

            return View(saviorVm);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        //     var logger= LogManager.GetLogger("FileLogger");
        //     logger.Log(LogLevel.Error, $"\n Xetanin bashverdiyi yer: {errorInfo.Path}\n Error Message: {errorInfo.Error.Message}\nStack" +
        //                                $"Trace:{errorInfo.Error.StackTrace}");
        //     return View();
        // }
        //
        public IActionResult Error()
        {
            return View();
        }
    }
}