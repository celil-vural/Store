using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.User
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
