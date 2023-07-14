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
                Cart.AddItem(product, 1);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            var product = Cart.Lines.FirstOrDefault(cl => cl.Product.ProductId.Equals(productId))?.Product;
            if (product is not null)
            {
                Cart.RemoveLine(product);
            }
            return Page();
        }
    }
}
