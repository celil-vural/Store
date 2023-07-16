using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _serviceManager;
        public ProductController(IProductService serviceManager)
        {
            _serviceManager = serviceManager;
        }


        public IActionResult Index(ProductRequestParameters p)
        {
            var model = _serviceManager.GetAllProductsWithDetails(p);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Product? product = _serviceManager.GetById(id);
            return View(product);
        }
    }
}