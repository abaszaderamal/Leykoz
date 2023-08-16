using System;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SlideController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public SlideController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.SlideService.GetAllAsync());
        }

        public async Task<IActionResult> Remove(int Id)
        {
            try
            {
                await _unitOfWorkService.SlideService.Remove(Id);
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SlidePostVM slideVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.SlideService.Create(slideVM);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("FormFiles", e.Message);
                    return View(slideVM);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(slideVM);
        }
    }
}