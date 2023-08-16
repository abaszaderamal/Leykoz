using System;

namespace Leykoz.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageURL { get; set; }
        // public IFormFile Photo { get; set; }
        // public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        // public bool Discount { get; set; }
        // public decimal DiscountPercent { get; set; }
    }
}