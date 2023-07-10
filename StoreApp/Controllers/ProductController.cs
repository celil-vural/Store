using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Concrete;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryManager<Product> _manager;
        public ProductController(RepositoryManager<Product> manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {
            var model = _manager.GetList().ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        {
            Product? product = _manager.Get(p => p.ProductId.Equals(id));
            return View(product);
        }
    }
}