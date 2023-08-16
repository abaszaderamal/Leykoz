using System;

namespace Leykoz.Business.ViewModels
{
    public class ReportYearVMPlus
    {
        public int id { get; set; }
        public string HeadTitle { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public int ReportCount { get; set; }
    }
}