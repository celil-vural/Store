using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contract;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;
        public CartModel(IProductService productService, Cart cart)
        {
            _productService = productService;
            Cart = cart;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _productService.GetById(productId, false);
            if (product is not null)
            {
                Cart.AddItem(product, Convert.ToInt16(1));
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            var orderDetail = Cart.Lines.FirstOrDefault(cl => cl.Product.ProductId.Equals(productId));
            if (orderDetail is not null)
            {
                Cart.RemoveLine(orderDetail);
            }
            return Page();
        }

        public IActionResult OnPostIncrease([FromForm] int productId)
        {
            Product? product = _productService.GetById(productId, false);
            if (product is not null)
            {
                Cart.AddItem(product, Convert.ToInt16(1));
            }
            return Page();

        }

        public IActionResult OnPostDecrease([FromForm] int productId)
        {
            var product = _productService.GetById(productId, false);
            if (product is not null)
            {
                Cart.RemoveItem(productId);
            }
            return Page();
        }
    }
}
