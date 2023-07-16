using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        List<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters);
    }
}
