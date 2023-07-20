using AutoMapper;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Services.Contract;

namespace Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
        public IEnumerable<IdentityUser> Users => _userManager.Users.ToList();
        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDtoForCreation)
        {
            var user = _mapper.Map<IdentityUser>(userDtoForCreation);
            var result = await _userManager.CreateAsync(user, userDtoForCreation.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User could not be created.");
            }

            if (userDtoForCreation.Roles?.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDtoForCreation.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with roles.");
                }
            }
            return result;
        }

        public async Task<IdentityUser> GetUserWithUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user ?? throw new Exception("User not found.");
        }

        public async Task UpdateUser(UserDtoForUpdate userDtoForUpdate)
        {
            if (userDtoForUpdate == null || userDtoForUpdate.UserName == null)
            {
                throw new Exception("User not found");
            }
            var user = await GetUserWithUserName(userDtoForUpdate.UserName);
            //_mapper.Map(userDtoForUpdate, user);
            user.Email = userDtoForUpdate.Email;
            user.PhoneNumber = userDtoForUpdate.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("User could not be updated.");
            }

            if (userDtoForUpdate.Roles?.Count > 0)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleResult = await _userManager.RemoveFromRolesAsync(user, roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with roles.");
                }
                roleResult = await _userManager.AddToRolesAsync(user, userDtoForUpdate.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with roles.");
                }
            }
        }

        public async Task<UserDtoForUpdate> GetUserDtoForUpdate(string userName)
        {
            var user = await GetUserWithUserName(userName);
            var userDtoForUpdate = _mapper.Map<UserDtoForUpdate>(user);
            userDtoForUpdate.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
            userDtoForUpdate.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDtoForUpdate;
        }

        public async Task<IdentityResult> ResetPassword(UserResetPasswordDto userResetPasswordDto)
        {
            if (userResetPasswordDto is null || userResetPasswordDto.UserName is null) throw new Exception("User not found");
            var user = await GetUserWithUserName(userResetPasswordDto.UserName);
            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, userResetPasswordDto.Password);
            return result;
        }

        public async Task<IdentityResult> DeleteUser(string userName)
        {
            var user = await GetUserWithUserName(userName);
            var result = await _userManager.DeleteAsync(user);
            return result;
        }
    }
}
