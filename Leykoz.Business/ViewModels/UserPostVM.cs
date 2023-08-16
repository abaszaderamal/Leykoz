using System.ComponentModel.DataAnnotations;

namespace Leykoz.Business.ViewModels
{
    public class UserPostVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}