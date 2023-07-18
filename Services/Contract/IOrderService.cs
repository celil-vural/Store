using Entities.Models;

namespace Services.Contract
{
    public interface IOrderService : IEntityService<Order>
    {
        void Complete(int id);
        void SaveOrder(Order order, bool trackChanges = false);
        int NumberOfInProcess { get; }
        IEnumerable<Order>? GetOrders(List<Order> orders);
        public Order? GetOrder(Order order);
    }
}
