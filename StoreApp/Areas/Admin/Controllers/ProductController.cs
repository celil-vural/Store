using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var entities = _productService.GetList().ToList();
            return View(entities);
        }

        public IActionResult Create()
        {
            var entities = _categoryService.GetList().ToList().ToList();
            ViewBag.Categories = entities;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        {
            return View();
        }
    }
}
