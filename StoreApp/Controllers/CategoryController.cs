using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var model = _categoryService.GetList().ToList();
            return View(model);
        }
    }
}
