using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string role = "default")
        {
            return role.Equals("default") ? View() : View("AdminProduct");
        }
    }
}
