using System;

namespace Leykoz.Core.Entities
{
    public class InfoSlide
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public string Contetnt { get; set; }
        public string MsgContetnt { get; set; }
        public string ImageFile { get; set; }
        public bool İsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        public string MsgTitleContetnt { get; set; }

        // public DateTime UpdatedDates { get; set; }
    }
}