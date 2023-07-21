using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ShowcaseViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke(string page = "default")
        {
            var products = _productService.GetList()?.ToList();
            return page.Equals("default") ?
                View(products) : View("List", products);
        }
    }
}
