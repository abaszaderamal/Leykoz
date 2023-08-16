using System.Collections.Generic;
using Leykoz.Core.Entities;

namespace Leykoz.Business.ViewModels
{
    public class HomeVM
    {
        public List<Slide> Slides { get; set; }

        public Dictionary<string, string> Setting { get; set; }

        //for post
        // public SaviorVM Savior { get; set; }
        // public string FullName { get; set; }
        // public string Email { get; set; }
        // public string ApplyType { get; set; }
        // public string Phone { get; set; }
        // public string ApplyContent { get; set; }
    }
}