using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Utilities;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        // GET
        public  async  Task<IActionResult>  Index()
        {
            // return View(await _unitOfWorkService.ProductService.GetAllAsync());
            ViewBag.Setting = await _unitOfWorkService.SiteSettingService.GetAllAsync();

            return View();
        }
        // GET
         [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> products = await _unitOfWorkService.ProductService.GetAllRadAsync();
            return Json(products);
        }
    }
}