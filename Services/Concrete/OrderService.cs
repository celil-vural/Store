using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IMapper mapper, IOrderRepository orderRepository) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
        }

        public override Order? GetById(int id, bool trackChanges = false)
        {
            return _orderRepository.Get(o => o.OrderId.Equals(id), trackChanges);
        }

        public override void Delete(int id, bool trackChanges = false)
        {
            Order? order = GetById(id, trackChanges);
            if (order == null) throw new Exception("Order Not Found!");
            _orderRepository.Delete(order);
            _orderRepository.SaveChanges();
        }
        public void Complete(int id)
        {
            _orderRepository.Complete(id);
            _orderRepository.SaveChanges();
        }

        public void SaveOrder(Order order, bool trackChanges = false)
        {
            _orderRepository.SaveOrder(order);
        }

        public int NumberOfInProcess { get; }
        public IEnumerable<Order>? GetOrders(List<Order> orders)
        {
            return _orderRepository.GetList();
        }

        public Order? GetOrder(Order order)
        {
            return GetById(order.OrderId);
        }
    }
}
