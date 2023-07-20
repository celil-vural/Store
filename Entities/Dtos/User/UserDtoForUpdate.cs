namespace Entities.Dtos.User
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}
