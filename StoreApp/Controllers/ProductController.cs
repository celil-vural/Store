using Entities.Models;
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


        public IActionResult Index()
        {
            var model = _serviceManager.GetList()?.ToList() ?? new List<Product>();
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Product? product = _serviceManager.GetById(id);
            return View(product);
        }
    }
}