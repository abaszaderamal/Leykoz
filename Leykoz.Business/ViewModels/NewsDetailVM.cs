using System.Collections.Generic;
using Leykoz.Core.Entities;

namespace Leykoz.Business.ViewModels
{
    public class NewsDetailVM
    {
        public News News { get; set; }
        public List<News> LastNews { get; set; }
    }
}