using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories.Concrete
{
    public sealed class ProductRepository : RepositoryManagerBase<Product>, IProductRepository
    {
        public ProductRepository(IRepositoryBase<Product> entity) : base(entity) { }
        public List<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters)
        {
            if (parameters != null)
                return GetList()?
                    .FilteredProductsByCategorId(parameters?.CategoryId)
                    .FilteredProductsBySearchTerm(parameters?.SearchTerm)
                    .FilterByPriceRange(parameters.MinPrice, parameters.MaxPrice, parameters.IsValidPriceRange);
            return GetList()?.ToList();
        }
    }
}