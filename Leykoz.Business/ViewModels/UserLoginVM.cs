using System.ComponentModel.DataAnnotations;

namespace Leykoz.Business.ViewModels
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "E-mail Tapılmadı")]
        [EmailAddress(ErrorMessage = "E-mail ünvanı səhvdir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş buraxma")]
        [DataType(DataType.Password,ErrorMessage = "Parol Yanlışdır")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        // public string EMail { get; set; }
        // public string Password { get; set; }
        // public bool RememberMe { get; set; }
    }
}