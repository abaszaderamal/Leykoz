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

    public class ProductController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.ProductService.GetAllPaginatedAsync(page));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                if (!productVm.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "file  should be  image type ");
                    return View(productVm);
                }

                if (!productVm.Photo.CheckFileSize(2048))
                {
                    ModelState.AddModelError("Photo", "file size must be less than 2mb");
                    return View(productVm);
                }

                try
                {
                    await _unitOfWorkService.ProductService.Create(productVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Product dbProduct = await _unitOfWorkService.ProductService.GetByIdAsync(id);
                return View(new ProductUpdateVM()
                {
                    Title = dbProduct.Title,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price,
                    Count = dbProduct.Count,
                    // Discount = dbProduct.Discount,
                    // DiscountPercent = dbProduct.DiscountPercent,
                    // IsNew = dbProduct.IsNew
                });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateVM productVm)
        {
            if (ModelState.IsValid)
            {
                if (productVm.Photo != null)
                {
                    if (!productVm.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "file  should be  image type ");
                        return View(productVm);
                    }

                    if (!productVm.Photo.CheckFileSize(2048))
                    {
                        ModelState.AddModelError("Photo", "file size must be less than 2mb");
                        return View(productVm);
                    }
                }

                try
                {
                    await _unitOfWorkService.ProductService.Update(id, productVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productVm);
        }


        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            try
            {
                await _unitOfWorkService.ProductService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return Redirect($"/AdminPanel/Product?page={page}");
        }
    }
}