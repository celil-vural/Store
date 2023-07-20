using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class OrderController : Controller
    {
        private readonly IOrderService _serviceManager;

        public OrderController(IOrderService serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var orders = _serviceManager.GetList()?.ToList() ?? new List<Order>();
            return View(orders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete([FromRoute(Name = "orderId")] int orderId)
        {
            _serviceManager.Complete(orderId);
            return RedirectToAction("Index");
        }
    }
}
