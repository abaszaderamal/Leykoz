using System;
using System.Collections.Generic;

namespace Leykoz.Core.Entities
{
    public class Savior
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ApplyType { get; set; }
        public string ApplyContent { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        // public List<Report> Reports { get; set; }
    }
}