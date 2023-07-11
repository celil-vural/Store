using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index()
        {
            var model = _productService.GetList().ToList();
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Product? product = _productService.GetById(id);
            return View(product);
        }
    }
}