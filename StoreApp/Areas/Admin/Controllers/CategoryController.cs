using Entities.Dtos.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddWithDtoForInsertion(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _categoryService.GetWithDtoForUpdate(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryDtoForUpdate categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateWithDtoForUpdate(categoryDto, true);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
