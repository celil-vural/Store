using Entities.Contracts;

namespace Entities.Dtos.ProductDtos
{
    public record class ProductDtoForUpdate : ProductDto, IDtoUpdateItem
    {
    }
}
