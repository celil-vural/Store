using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class ProductManager : RepositoryManager<Product>
    {
        public ProductManager(IEntityRepository<Product> entity) : base(entity) { }

    }
}
