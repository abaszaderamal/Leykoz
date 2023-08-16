using System;
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
    public class ReportController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly AppDbContext _context;

        public ReportController(IUnitOfWorkService unitOfWorkService, AppDbContext context)
        {
            _unitOfWorkService = unitOfWorkService;
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // await CreateSaviorDataFast(500);
            return View(await _unitOfWorkService.ReportService.GetPasinateAllAsync(page, 10));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.ReportService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }   
        public async Task<IActionResult> DeleteAmount(int id)
        {
            try
            {
                await _unitOfWorkService.ReportAmountService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return Redirect($"/AdminPanel/Report/");
        } 
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                Report dbReport = await _unitOfWorkService.ReportService.GetByIdAsync(id);
                if (dbReport == null) NotFound();
                return View(dbReport.ReportAmounts);
            }
            catch
            {
                return NotFound();
            }
         }

        public IActionResult CreateAmount(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAmount(int id, ReportAmountVM reportAmountVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.ReportAmountService.CreateAsync(id, reportAmountVm);
                return RedirectToAction(nameof(Index));
            }

            return View(reportAmountVm);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReportVM reportVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.ReportService.CreateAsync(reportVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(reportVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Report report = await _unitOfWorkService.ReportService.GetByIdAsync(id);
                return View(new ReportVM { Name = report.Name, SurName = report.SurName, IsPublic = !report.IsPublic });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ReportVM reportVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.ReportService.UpdateAsync(id, reportVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(reportVm);
        }


        public async Task CreateSaviorDataFast(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await _context.Reports.AddAsync(new Report()
                {
                    //                   Amount = 555,
                    CreatedAt = DateTime.Now,
                    // IsPublic = true,
                    // SaviorId = 1
                });
                Console.WriteLine(i);
                await _context.SaveChangesAsync();
            }
        }
    }
}