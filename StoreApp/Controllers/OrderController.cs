using Entities.Dtos.OrderDtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShipperService _shipperService;
        private readonly Cart _cart;
        private readonly IOrderService _orderService;
        public OrderController(IShipperService shipperService, Cart cart, IOrderService orderService)
        {
            _shipperService = shipperService;
            _cart = cart;
            _orderService = orderService;
        }

        public ViewResult Checkout()
        {
            ViewBag.Shippers = GetCategoriesSelectList();
            return View(new OrderDtoForInsertion());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] OrderDtoForInsertion dtoForInsertion)
        {
            if (_cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                dtoForInsertion.OrderDetails = _cart.Lines.ToList();
                _orderService.SaveOrder(order: dtoForInsertion);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = dtoForInsertion.OrderId });
            }

            return View();
        }
        private SelectList GetCategoriesSelectList()
        {
            var entities = GetShippers();
            return new SelectList(entities, "ShipperId", "CompanyName", "1");
        }
        private List<Shipper>? GetShippers()
        {
            var entities = _shipperService.GetList()?.ToList() ?? new List<Shipper>();
            return entities;
        }
    }
}
