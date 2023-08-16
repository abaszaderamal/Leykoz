using System;
using System.Collections.Generic;

namespace Leykoz.Core.Entities
{
    public class Report
    {
        public int Id { get; set; }    
        public string PrivateName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        //public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ReportAmount> ReportAmounts  { get; set; }
        // public int SaviorId { get; set; }
        // public Savior Savior { get; set; }
    }
}