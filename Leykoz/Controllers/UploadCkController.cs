using System;
using System.IO;
using System.Threading.Tasks;
using Leykoz.Areas.AdminPanel.Models;
using Leykoz.Business.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Controllers
{
    public class uploadsuccess
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }

    public class UploadCkController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public UploadCkController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult St(Ckvm t)
        // {
        //     return null;
        // }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;

            //your custom code logic here

            //1)check if the file is image

            //2)check if the file is too large

            //etc

            string fileName = await upload.SaveFileAsync(_env.WebRootPath, "src", "img");


            // var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            //save file under wwwroot/CKEditorImages folder
            //
            // var filePath = Path.Combine(
            //     Directory.GetCurrentDirectory(), "wwwroot/CKEditorImages",
            //     fileName);

            // using (var stream = System.IO.File.Create(filePath))
            // {
            //     await upload.CopyToAsync(stream);
            // }

            var url = $"{"/src/img/"}{fileName}";

            var success = new uploadsuccess
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url
            };

            return new JsonResult(success);
        }
    }
}