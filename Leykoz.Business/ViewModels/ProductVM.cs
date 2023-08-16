using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.ViewModels
{
    public class ProductVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public IFormFile Photo { get; set; }
        public string ImageURL { get; set; }
        // public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        // public bool Discount { get; set; }
        // public decimal DiscountPercent { get; set; }
    }
}