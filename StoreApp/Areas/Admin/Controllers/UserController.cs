using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Data;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var users = _authService.Users;
            return View(users);
        }

        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_authService.Roles.Select(r => r.Name).ToList())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation dtoForCreation)
        {
            try
            {
                var result = await _authService.CreateUser(dtoForCreation);
                return result.Succeeded ? RedirectToAction("Index") : View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _authService.GetUserDtoForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDtoForUpdate)
        {
            if (!ModelState.IsValid) View();
            await _authService.UpdateUser(userDtoForUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new UserResetPasswordDto() { UserName = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] UserResetPasswordDto userResetPasswordDto)
        {
            if (!ModelState.IsValid) View();
            var result = await _authService.ResetPassword(userResetPasswordDto);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser([FromForm] UserDto userDto)
        {
            if (!ModelState.IsValid || userDto.UserName is null) View();
            var result = await _authService.DeleteUser(userDto.UserName);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }
    }
}
