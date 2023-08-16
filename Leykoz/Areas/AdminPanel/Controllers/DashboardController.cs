using System;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWorkService unitOfWorkService, IUnitOfWork unitOfWork)
        {
            _unitOfWorkService = unitOfWorkService;
            _unitOfWork = unitOfWork;
        }

        [Route("adminpanel")]
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.DashBoardService.GetAllCountAsync());
        }

        // public async Task Danger()
        // {
        //     for (int i = 0; i < 100; i++)
        //     {
        //         await _unitOfWork.ProductRepository.CreateAsync(new Product()
        //         {
        //             CreatedAt = DateTime.Now,
        //             Count = 25,
        //             Description = "<p>Məhsul Məzmunu</p>",
        //             Price = 24,
        //             Title = "Test Məhsul",
        //             ImageURL = "https://leykoz.az/src/img/06122022082430_product.png"
        //         });
        //         Console.WriteLine(i);
        //     }
        //
        //     await _unitOfWork.SaveAsync();
        //     //  await DangerN();
        // }
        // public async Task Danger()
        // {
        //     for (int i = 0; i < 100; i++)
        //     {
        //         await _unitOfWork.NewsRepository.CreateAsync(new News()
        //         {
        //             Contetnt =
        //                 @"<p>Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır.&nbsp;Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır.<br>&nbsp;</p>",
        //             Name = "Bir ailənin sevinci hamımızın sevincidir!",
        //             Title =
        //                 "<p>Gözəl Ramazan Bayramının ruzisi ianələr sayəsində ailələrimizin süfrələrinə də getdi, 57 ailəyə ərzaq yardımı edildi, ümumi 2389 manat xərcləndi.</p>",
        //             ImageFile = "06122022081415_23b5e97837b9ebe2ba31750ac6a37897.jfif",
        //             CreatedDate = DateTime.Now
        //         });
        //         Console.WriteLine(i);
        //     }
        //
        //     await _unitOfWork.SaveAsync();
        //   //  await DangerN();
        // }
        // public async Task Danger()
        // {
        //     for (int i = 0; i < 100; i++)
        //     {
        //         await _unitOfWork.InfoSlideRepository.CreateAsync(new InfoSlide()
        //         {
        //             Contetnt = "<p>Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və</p>",
        //             Title = "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin	",
        //             CreatedDate = DateTime.Now,
        //             ImageFile = "https://leykoz.az/src/img/06122022080338_a77c0b8ce89f568cdfb3fe93de27f73b.jfif",
        //             LastName = "Əliyeva",
        //             FirstName = "Səadət",
        //             MsgContetnt = "<p>Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır.</p>",
        //             MsgTitleContetnt = "Səadətdən məktub"
        //         });
        //         Console.WriteLine(i);
        //     }
        //
        //     await _unitOfWork.SaveAsync();
        // }
    }
}