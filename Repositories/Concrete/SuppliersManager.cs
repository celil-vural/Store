using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class SuppliersManager : RepositoryManagerBase<Supplier>, ISuppliersManager
    {
        public SuppliersManager(IRepositoryBase<Supplier> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
