using Entities.Contracts;
using Entities.Dtos.ProductDtos;
using Entities.Models;

namespace Services.Contract
{
    public interface IProductService : IEntityService<Product>
    {
        public Product? AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false);
        public ProductDtoForUpdate? UpdateWithDtoForUpdate(ProductDtoForUpdate productDto, bool trackChanges = false);
        public ProductDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false);
    }
}
