using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _serviceManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailManager _orderDetailManager;
        public CategoryController(ICategoryService serviceManager, IOrderService orderService, IOrderDetailManager orderDetailManager)
        {
            _serviceManager = serviceManager;
            _orderService = orderService;
            _orderDetailManager = orderDetailManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.GetList()?.ToList() ?? new List<Category>();
            var orders = _orderService.GetList()?.ToList() ?? new List<Order>();
            ViewBag.Orders = orders;
            string script = $"console.log('{orders.Count}');";
            ViewBag.ConsoleLogScript = script;
            return View(model);
        }
    }
}