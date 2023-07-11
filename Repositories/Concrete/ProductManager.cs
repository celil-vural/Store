using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class ProductManager : RepositoryManagerBase<Product>, IProductManager
    {
        public ProductManager(IRepositoryBase<Product> entity) : base(entity) { }
    }
}
