using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class ProductManager : RepositoryManager<Product>
    {
        public ProductManager(IRepositoryBase<Product> entity) : base(entity) { }
    }
}
