using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetList().ToList();
            return View(categories);
        }
    }
}
