using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class EventController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public EventController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWorkService.EventService.GetAllAsync());
        }


        #region Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventVM eventVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.EventService.AddAsync(eventVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(eventVm);
        }

        #endregion

        #region Update

        public async Task<ActionResult> Edit(int id)
        {
            EventUpdateVM dbEvent = await _unitOfWorkService.EventService.GetByIdAsync(id);
            if (dbEvent is null)
            {
                return NotFound();
            }

            return View(dbEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EventUpdateVM eventVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.EventService.UpdateAsync(id, eventVm);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            return View(eventVm);
        }

        #endregion

        #region Delete

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.EventService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

    }

}