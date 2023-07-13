using Entities.Dtos.ProductDtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                _productService.AddWithDtoForInsertion(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _productService.GetWithDtoForUpdate(id);
            ViewBag.Categories = GetCategoriesSelectList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductDtoForUpdate productDto)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateWithDtoForUpdate(productDto, true);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
        private SelectList GetCategoriesSelectList()
        {
            var entities = GetCategories();
            return new SelectList(entities, "CategoryId", "CategoryName", "1");
        }

        private List<Category>? GetCategories()
        {
            var entities = _categoryService.GetList().ToList().ToList();
            return entities;
        }
    }
}
