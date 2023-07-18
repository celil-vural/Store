using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductSummaryViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public string Invoke()
        {
            return (_productService.GetList()?.ToList().Count ?? 0).ToString();
        }
    }
}
