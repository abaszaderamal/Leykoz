using System;

namespace Leykoz.Core.Entities
{
    public class ReportAmount
    {
        public int Id { get; set; }

        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}