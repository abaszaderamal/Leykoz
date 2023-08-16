using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class InfoSlidePutVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Contetnt { get; set; }
        public string MsgContetnt { get; set; }
        public IFormFile Image { get; set; }
        public string ImageFile { get; set; }
        public string MsgTitleContetnt { get; set; }


    }
}