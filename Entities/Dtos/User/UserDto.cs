using System.ComponentModel.DataAnnotations;
namespace Entities.Dtos.User
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        public HashSet<string>? Roles { get; set; } = new();
    }
}