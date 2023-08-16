using System;

namespace Leykoz.Core.Entities
{
    public class ReportYear
    {
        public int Id { get; set; }
        public string HeadTitle { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public bool IsDeleted { get; set; }
    }
}