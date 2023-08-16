using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public NewsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page=1)
        { 
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();

            return View(await _unitOfWorkService.NewsService.GetAllPaginatedAsync(page,9));
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();

             
                NewsDetailVM AllNews = new NewsDetailVM()
                {
                    News = await _unitOfWorkService.NewsService.DetailAsync(id),
                    LastNews = (await _unitOfWorkService.NewsService.GetAllPaginatedAsync(1, 3)).Items
                };
                return View(AllNews);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}