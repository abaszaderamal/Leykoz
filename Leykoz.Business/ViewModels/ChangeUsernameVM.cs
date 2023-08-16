using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace Leykoz.Business.ViewModels
{
    public class ChangeUsernameVM
    {
        public string NewUsername { get; set; }
        public string Password { get; set; }
    }
}