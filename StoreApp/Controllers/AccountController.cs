using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);
                if (user == null)
                {
                    ModelState.AddModelError("Error", "Invalid user or password");
                    return View();
                }

                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("Error", "Your account has not been confirmed yet. Please check your email inbox and click on the confirmation link to activate your account. If you haven't received the email, please check your spam folder. If you need further assistance, please contact our support team.");
                    return View();
                }
                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                {
                    return Redirect(model?.ReturnUrl ?? "/");
                }

            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new IdentityUser() { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Login", new { ReturnUtl = "/" });
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Error", error.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
