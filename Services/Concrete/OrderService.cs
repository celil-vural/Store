using AutoMapper;
using Entities.Contracts;
using Entities.Dtos.OrderDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IOrderManager _managerBase;
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public OrderService(IOrderManager managerBase, IMapper mapper, IOrderDetailManager orderDetailManager, IProductService productService) : base(managerBase, mapper)
        {
            _managerBase = managerBase;
            _orderDetailManager = orderDetailManager;
            _productService = productService;
            _mapper = mapper;
        }
        public override IList<Order> GetList(bool trackChanges = false)
        {
            var orderList = _managerBase.GetList(trackChanges)?.ToList() ?? new List<Order>();
            orderList = GetIncludeOrders(orderList)?.ToList();
            return orderList?.OrderByDescending(o => o.OrderId).ToList() ?? new List<Order>();
        }
        public override Order? GetById(int id, bool trackChanges = false)
        {
            Order order = _managerBase.Get(o => o.OrderId.Equals(id), trackChanges) ?? new Order();
            return GetIncludeOrder(order);
        }

        public override void Delete(int id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public void Complete(int id)
        {
            var order = GetById(id, true);
            if (order is null) throw new Exception("Order could not found");
            order.Shipped = true;
            order.Complete = true;
            _managerBase.SaveChanges();
        }

        public void SaveOrder(OrderDtoForInsertion orderDtoForInsertion, bool trackChanges = false)
        {
            var order = _mapper.Map<Order>(orderDtoForInsertion);
            _managerBase.Add(order, trackChanges);
            order.OrderDetails?.ForEach(od =>
            {
                _orderDetailManager.Add(od);
            });
            _orderDetailManager.SaveChanges();
            _managerBase.SaveChanges();
        }
        public int NumberOfInProcess()
        {
            var orderCount = _managerBase.GetList(false)?.Count(o => o.Shipped) ?? 0;
            return orderCount;
        }

        public Order? GetIncludeOrder(Order order)
        {
            var orderId = order.OrderId;
            var orderDetails = _orderDetailManager.GetList(false, od => od.OrderId == orderId)?.ToList();
            order.OrderDetails = orderDetails ?? new List<OrderDetail>();
            return order;
        }
        public IList<Order>? GetIncludeOrders(List<Order> orders)
        {
            orders.ForEach(o =>
            {
                var orderId = o.OrderId;
                var orderDetails = _orderDetailManager.GetList(false, od => od.OrderId == orderId)?.ToList() ?? new List<OrderDetail>();
                orderDetails = IncludeOrderDetails(orderDetails);
                o.OrderDetails = orderDetails;
            });
            return orders;
        }

        private List<OrderDetail> IncludeOrderDetails(List<OrderDetail> orderDetails)
        {
            orderDetails.ForEach(od =>
            {
                var productId = od.ProductId;
                var product = _productService.GetById(productId, false);
                od.ProductName = product?.ProductName ?? "";
                od.Product = product;
            });
            return orderDetails;
        }
        public Order AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }
        public OrderDtoForUpdate? UpdateWithDtoForUpdate(OrderDtoForUpdate orderDto, bool trackChanges = false)
        {
            var entity = _mapper.Map<Order>(orderDto);
            _managerBase.Update(entity, trackChanges);
            _managerBase.SaveChanges();
            return orderDto;
        }

        public OrderDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }
    }
}
