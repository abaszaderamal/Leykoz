using System;

namespace Leykoz.Core.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Contetnt { get; set; }
        public string ImageFile { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}