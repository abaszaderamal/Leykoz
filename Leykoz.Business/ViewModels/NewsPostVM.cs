using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class NewsPostVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Contetnt { get; set; }
        public IFormFile Image { get; set; }
    }
}