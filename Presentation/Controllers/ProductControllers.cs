using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace Presentation.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetList());
        }
    }
}
