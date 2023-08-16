using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class SlidePostVM
    {
        public List<IFormFile> FormFiles { get; set; }
    }
}