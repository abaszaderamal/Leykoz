using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leykoz.Core.Entities
{
    public class Slide
    {
     
        public int Id { get; set; }
        //  public DateTime UpdatedDates { get; set; }
        public string ImageFile { get; set; }
        // [NotMapped]
        // public IFormFile Image { get; set; }
    }
}