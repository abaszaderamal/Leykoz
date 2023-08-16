using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Leykoz.Business.ViewModels
{
    public class SaviorVM
    {
        [DisplayName("Ad, soyad")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ApplyType { get; set; }
        public string Phone { get; set; }
        public string ApplyContent { get; set; }
    }
}