using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get => _returnUrl ?? "/";
            set => _returnUrl = value;
        }
    }
}
