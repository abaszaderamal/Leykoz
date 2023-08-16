using System;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Utilities;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class NewsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly AppDbContext _context;


        public NewsController(IUnitOfWorkService unitOfWorkService, AppDbContext context)
        {
            _unitOfWorkService = unitOfWorkService;
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // await CreateNewsDataFast(5000);
            return View(await _unitOfWorkService.NewsService.GetAllPaginatedAsync(page,10));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewsPostVM newsPostVm)
        {
            if (ModelState.IsValid)
            {
                if (!newsPostVm.Image.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "file  should be  image type ");
                    return View(newsPostVm);
                }

                if (!newsPostVm.Image.CheckFileSize(2048))
                {
                    ModelState.AddModelError("Image", "file size must be less than 2mb");
                    return View(newsPostVm);
                }

                try
                {
                    await _unitOfWorkService.NewsService.Create(newsPostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(newsPostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(newsPostVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                News dbNews = await _unitOfWorkService.NewsService.GetByIdAsync(id);
                return View(new NewsPutVM()
                {
                    Name = dbNews.Name,
                    Title = dbNews.Title,
                    Contetnt = dbNews.Contetnt,
                });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, NewsPutVM newsPutVm)
        {
            if (ModelState.IsValid)
            {
                if (newsPutVm.Image != null)
                {
                    if (!newsPutVm.Image.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("ImageFile", "file  should be  image type ");
                        return View(newsPutVm);
                    }

                    if (!newsPutVm.Image.CheckFileSize(2048))
                    {
                        ModelState.AddModelError("ImageFile", "file size must be less than 2mb");
                        return View(newsPutVm);
                    }
                }

                try
                {
                    await _unitOfWorkService.NewsService.Update(id, newsPutVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(newsPutVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(newsPutVm);
        }

        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            try
            {
                await _unitOfWorkService.NewsService.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return Redirect($"/AdminPanel/News?page={page}");
        }

        public async Task CreateNewsDataFast(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await _context.News.AddAsync(new News()
                {
                    Contetnt = "sdfsf",
                    Name = "dsfsdf",
                    Title = "dsfsdf",
                    CreatedDate = DateTime.Now,
                    ImageFile = "05222022055128_Screenshot%202022-05-21%20123107.png"
                });
                Console.WriteLine(i);
                await _context.SaveChangesAsync();
            }
        }
    }
}