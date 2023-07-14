using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        public IActionResult Index()
        {
            var model = _serviceManager.ProductService.GetList().ToList();
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Product? product = _serviceManager.ProductService.GetById(id);
            return View(product);
        }
    }
}