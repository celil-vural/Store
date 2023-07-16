using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class OrderDetailManager : RepositoryManagerBase<OrderDetail>, IOrderDetailManager
    {
        public OrderDetailManager(IRepositoryBase<OrderDetail> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
