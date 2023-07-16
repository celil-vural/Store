using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class OrderManager : RepositoryManagerBase<Order>, IOrderManager
    {
        public OrderManager(IRepositoryBase<Order> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
