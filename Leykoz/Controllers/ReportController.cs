using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly AppDbContext _context;

        public ReportController(IUnitOfWorkService unitOfWorkService, AppDbContext context)
        {
            _context = context;
            _unitOfWorkService = unitOfWorkService;
        }


        // GET
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();
            var c = await _unitOfWorkService.ReportAmountService.GetPasinateAllAsync(page, 9);
            return View(await _unitOfWorkService.ReportAmountService.GetPasinateAllAsync(page, 9));
        }

        public async Task<IActionResult> ExportToExcel(int id)
        {
            ReportYearVM reportYearVm = await _unitOfWorkService.ReportYearService.GetByIdAsync(id);
            if (reportYearVm is null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reports");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad";
                worksheet.Cell(currentRow, 2).Value = "Soyad";
                worksheet.Cell(currentRow, 3).Value = "Məxfi Ad";
                worksheet.Cell(currentRow, 4).Value = "Məbləğ";
                worksheet.Cell(currentRow, 5).Value = "Tarix";

                worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);

                // List<ReportAmount> amounts = await _unitOfWorkService.ReportAmountService.GetAllByDateAsync(reportYearVm.Year);
                List<ReportAmount> amounts =
                  await  _context
                        .ReportAmounts
                        .Where(p => p.IsDeleted == false && p.CreatedAt.Year ==reportYearVm.Year.Year )
                        .Include(p=>p.Report)
                        .Where(p=>p.Report.IsDeleted==false)
                        .ToListAsync();

                foreach (var Report in amounts)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = Report.Report.Name;
                    worksheet.Cell(currentRow, 2).Value = Report.Report.SurName;
                    worksheet.Cell(currentRow, 3).Value = Report.Report.PrivateName;
                    worksheet.Cell(currentRow, 4).Value = Report.Amount;
                    worksheet.Cell(currentRow, 5).Value = Report.CreatedAt;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Reports_{DateTime.Now.ToString()}.xlsx");
                }
            }
        }
    }
}