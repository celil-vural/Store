using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _productService.GetAllProductsWithDetails(p) ?? new List<Product>();
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _productService.GetList()?.Count() ?? 0
            };
            return View(new ProductListViewModel()
            {
                Products = products.ToList(),
                Pagination = pagination
            });
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Product? product = _productService.GetById(id);
            return View(product);
        }
    }
}