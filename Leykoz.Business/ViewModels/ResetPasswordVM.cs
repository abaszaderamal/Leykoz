using System.ComponentModel.DataAnnotations;

namespace Leykoz.Business.ViewModels
{
    public class ResetPasswordVM
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}