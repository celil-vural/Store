using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories.Concrete
{
    public sealed class ProductRepository : RepositoryManagerBase<Product>, IProductRepository
    {
        public ProductRepository(IRepositoryBase<Product> entity) : base(entity) { }
        public IEnumerable<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters)
        {
            if (parameters != null)
                return GetList()?
                    .FilteredProductsByCategorId(parameters?.CategoryId)
                    .FilteredProductsBySearchTerm(parameters?.SearchTerm)
                    .FilterByPriceRange(parameters?.MinPrice ?? 0, parameters?.MaxPrice ?? decimal.MaxValue, parameters?.IsValidPriceRange)
                    .SortBy(parameters?.SortBy)
                    .ToPaginatedList(parameters?.PageNumber, parameters?.PageSize);
            return GetList();
        }

        public IEnumerable<Product>? GetShowcaseProducts(bool trackChanges)
        {
            return GetList(trackChanges)?
                .Where(p => p.ShowCase.Equals(true));
        }
    }
}