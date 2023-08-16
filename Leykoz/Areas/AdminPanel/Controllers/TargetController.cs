using System;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class TargetController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public TargetController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWorkService.TargetService.GetAllAcync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TargetVM targetVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.TargetService.Add(targetVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(targetVm);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Target dbTarget = await _unitOfWorkService.TargetService.GetByIdAsync(id);
            if (dbTarget is null)
            {
                return NotFound();
            }

            return View(new TargetVM { Content = dbTarget.Content });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TargetVM targetVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.TargetService.Update(id, targetVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(targetVm);
            // return Redirect($"/AdminPanel/Target/Edit/{id}");
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.TargetService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}