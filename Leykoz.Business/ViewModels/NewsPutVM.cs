using System;
using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class NewsPutVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Contetnt { get; set; }
        public IFormFile Image { get; set; }
        public string ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}