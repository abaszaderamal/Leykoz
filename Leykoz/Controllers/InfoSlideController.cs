using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Controllers
{
    // [Route("api/[controller]")]

    public class InfoSlideController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public InfoSlideController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        
        public async Task<IActionResult> Index()
        {      
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();

            return View();
        }
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetHeadSlides()
        {
            return Json(await _unitOfWorkService.InfoSlideService.GetAllRadAsync());
        }
    }
}