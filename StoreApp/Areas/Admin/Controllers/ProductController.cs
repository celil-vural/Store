using Entities.Dtos.Product;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            var products = _productService.GetAllProductsWithDetails(p) ?? new List<Product>();
            ViewBag.Categories = GetCategories() ?? new List<Category>();
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _productService.GetList()?.Count() ?? 0
            };
            return View(new ProductListViewModel()
            {
                Products = products.ToList(),
                Pagination = pagination
            });
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // Dosya işlemleri
                try
                {
                    if (file != null && file.Length > 0)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        productDto.ImageUrl = String.Concat("/images/", file.FileName);
                        _productService.AddWithDtoForInsertion(productDto);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Lütfen bir resim seçin.");
                    return View(productDto);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Dosya yükleme işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }

            return View(productDto);
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
            var entities = _categoryService.GetList()?.ToList() ?? new List<Category>();
            return entities;
        }
    }
}
