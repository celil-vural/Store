using Entities.Dtos.OrderDtos;
using Entities.Models;

namespace Services.Contract
{
    public interface IOrderService : IEntityService<Order>, IServiceWithDto<Order, OrderDtoForUpdate>
    {
        void Complete(int id);
        void SaveOrder(OrderDtoForInsertion order, bool trackChanges = false);
        int NumberOfInProcess();
        IList<Order>? GetIncludeOrders(List<Order> orders);
        public Order? GetIncludeOrder(Order order);
    }
}
