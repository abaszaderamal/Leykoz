using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class InfoSlidePostVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Contetnt { get; set; }
        public string MsgContetnt { get; set; }
        public IFormFile ImageFile { get; set; }
        public string MsgTitleContetnt { get; set; }

    }
}