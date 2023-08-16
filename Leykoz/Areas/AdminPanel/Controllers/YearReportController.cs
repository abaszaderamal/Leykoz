using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class YearReportController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public YearReportController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.ReportYearService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReportYearVM reportYearVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.ReportYearService.CreateAsync(reportYearVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(reportYearVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            ReportYearVM dbEvent = await _unitOfWorkService.ReportYearService.GetByIdAsync(id);
            if (dbEvent is null)
            {
                return NotFound();
            }

            return View(dbEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ReportYearVM reportYearVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.ReportYearService.UpdateAsync(id, reportYearVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(reportYearVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.ReportYearService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}