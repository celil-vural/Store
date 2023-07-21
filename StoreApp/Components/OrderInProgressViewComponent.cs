using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class OrderInProgressViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public OrderInProgressViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public string Invoke() => _orderService.GetList()?.Count().ToString() ?? "0";
    }
}
