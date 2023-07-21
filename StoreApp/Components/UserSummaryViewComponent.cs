using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly IAuthService _authService;

        public UserSummaryViewComponent(IAuthService authService)
        {
            _authService = authService;
        }

        public string Invoke() => _authService.Users?.Count().ToString() ?? "0";
    }
}
