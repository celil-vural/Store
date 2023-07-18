using Entities.Dtos.Product;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contract
{
    public interface IProductService : IEntityService<Product>
    {
        public Product? AddWithDtoForInsertion(ProductDtoForInsertion productDto, bool trackChanges = false);
        public ProductDtoForUpdate? UpdateWithDtoForUpdate(ProductDtoForUpdate productDto, bool trackChanges = false);
        public ProductDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false);
        IEnumerable<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters);
        public List<Product>? GetLastestProducts(int count, bool trackChanges = false);
        IEnumerable<Product>? GetShowcaseProducts(bool trackChanges = false);
        ProductDtoForUpdate? GetOneProductForUpdate(int id, bool trackChanges = false);
    }
}
