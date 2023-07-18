using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.EntityFramework;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class OrderRepository : RepositoryManagerBase<Order>, IOrderRepository
    {
        private readonly RepositoryContext _context;
        public OrderRepository(IRepositoryBase<Order> repositoryBase, RepositoryContext context) : base(repositoryBase)
        { }

        public IEnumerable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId).ToList();
        public Order? GetOrder(int id)
        {
            return Get(o => o.OrderId.Equals(id), true);
        }

        public void Complete(int id)
        {
            var order = Get(o => o.OrderId.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                Add(order, true); // Yeni siparişi ekleyin
            }
            else
            {
                Update(order, true); // Mevcut siparişi güncelleyin
            }

            SaveChanges();
        }
        public int NumberOfInProcess => GetList()?.Count(o => o.Shipped.Equals(false)) ?? 0;
    }
}
