using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.User
{
    public record UserResetPasswordDto
    {
        public string? UserName { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string? ConfirmPassword { get; init; }
    }
}
