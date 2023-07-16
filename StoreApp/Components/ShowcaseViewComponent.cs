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
        public IViewComponentResult Invoke()
        {
            var products = _productService.GetList();
            return View(products);
        }
    }
}
