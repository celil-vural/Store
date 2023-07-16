using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class CustomerManager : RepositoryManagerBase<Customer>, ICustomerManager
    {
        public CustomerManager(IRepositoryBase<Customer> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
