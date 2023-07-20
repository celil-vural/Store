using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace Services.Contract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> Users { get; }
        Task<IdentityResult> CreateUser(UserDtoForCreation userDtoForCreation);
        Task<IdentityUser> GetUserWithUserName(string userName);
        Task UpdateUser(UserDtoForUpdate userDtoForUpdate);
        Task<UserDtoForUpdate> GetUserDtoForUpdate(string userName);
        Task<IdentityResult> ResetPassword(UserResetPasswordDto userResetPasswordDto);
        Task<IdentityResult> DeleteUser(string userName);
    }
}
