using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly IOrderService _orderService;
        public OrderController(Cart cart, IOrderService orderService)
        {
            _cart = cart;
            _orderService = orderService;
        }
        [Authorize(Roles = "Admin,Editor,User")]
        public ViewResult Checkout() => View(new Order());
        [Authorize(Roles = "Admin,Editor,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart?.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if (ModelState.IsValid && _cart != null)
            {
                order.Lines = _cart.Lines.ToArray();
                _orderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            return View();
        }
    }
}
