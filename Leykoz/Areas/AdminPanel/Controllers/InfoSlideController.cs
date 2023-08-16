using System;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Utilities;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class InfoSlideController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public InfoSlideController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.InfoSlideService.GetAllPaginatedAsync(page));
        }

        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            try
            {
                await _unitOfWorkService.InfoSlideService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return Redirect($"/AdminPanel/InfoSlide?page={page}");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InfoSlidePostVM infoSlideVm)
        {
            if (ModelState.IsValid)
            {
                if (!infoSlideVm.ImageFile.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "file  should be  image type ");
                    return View(infoSlideVm);
                }

                if (!infoSlideVm.ImageFile.CheckFileSize(2048))
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 2 mb");
                    return View(infoSlideVm);
                }

                try
                {
                    await _unitOfWorkService.InfoSlideService.Create(infoSlideVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(infoSlideVm);
                }
            }

            return View(infoSlideVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                InfoSlide dbInfoSlide = await _unitOfWorkService.InfoSlideService.GetByIDAsync(id);
                return View(new InfoSlidePutVM()
                {
                    FirstName = dbInfoSlide.FirstName,
                    LastName = dbInfoSlide.LastName,
                    Contetnt = dbInfoSlide.Contetnt,
                    Title = dbInfoSlide.Title,
                    MsgContetnt = dbInfoSlide.MsgContetnt,
                    MsgTitleContetnt = dbInfoSlide.MsgTitleContetnt
                });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, InfoSlidePutVM infoSlidePutVm)
        {
            if (ModelState.IsValid)
            {
                if (infoSlidePutVm.ImageFile != null)
                {
                    if (!infoSlidePutVm.Image.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Image", "file  should be  image type ");
                        return View(infoSlidePutVm);
                    }

                    if (!infoSlidePutVm.Image.CheckFileSize(2048))
                    {
                        ModelState.AddModelError("Image", "file size must be less than 2 mb");
                        return View(infoSlidePutVm);
                    }
                }

                try
                {
                    await _unitOfWorkService.InfoSlideService.Update(id, infoSlidePutVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(infoSlidePutVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(infoSlidePutVm);
        }
    }
}