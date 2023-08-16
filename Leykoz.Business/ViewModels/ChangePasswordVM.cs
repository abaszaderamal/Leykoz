using System.ComponentModel.DataAnnotations;

namespace Leykoz.Business.ViewModels
{
    public class ChangePasswordVM
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}