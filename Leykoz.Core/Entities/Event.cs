using System;

namespace Leykoz.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}