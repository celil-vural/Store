using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        IEnumerable<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters);
        IEnumerable<Product>? GetShowcaseProducts(bool trackChanges);
    }
}
