using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _serviceManager;
        public CategoryController(ICategoryService serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.GetList()?.ToList() ?? new List<Category>();
            return View(model);
        }
    }
}