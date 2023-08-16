using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SaviorController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        // private readonly AppDbContext _context;

        public SaviorController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            // _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // await CreateSaviorData(5000);
            // await CreateSaviorDataFast(150);
            // Stopwatch t = new Stopwatch();
            // t.Start();
            // await CreateNews(3500);
            Paginate<Savior> DbData = await _unitOfWorkService.SaviorService.GetAllAsync(page, 10);

            // t.Stop();
            // Console.WriteLine(t.ElapsedMilliseconds );
            return View(DbData);
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.SaviorService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string search, int page = 0)
        {
            if (search is null)
            {
                return View();
            }

            PaginateFast<Savior> saviors = null;
            if (page != 0)
            {
                saviors = await _unitOfWorkService.SaviorService.GetAllPaginatedSAsync(
                    search,
                    page, 10);
                saviors.search = search;
            }

            return View(saviors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(PaginateFast<Savior> paginateFast)
        {
            if (paginateFast.search is null)
            {
                return View();
            }

            Stopwatch t = new Stopwatch();
            t.Start();
            paginateFast.CurrentPage = paginateFast.CurrentPage == 0 ? 1 : paginateFast.CurrentPage;
            PaginateFast<Savior> saviors = await _unitOfWorkService.SaviorService.GetAllPaginatedSAsync(
                paginateFast.search,
                paginateFast.CurrentPage, 10);
            saviors.search = paginateFast.search;

            t.Stop();
            Console.WriteLine("axtaris muddeti   " + t.ElapsedMilliseconds);
            return View(saviors);
        }

        
    }
}