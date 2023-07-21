using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategorySummaryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public string Invoke() => _categoryService.GetList()?.Count().ToString() ?? "0";
    }
}
