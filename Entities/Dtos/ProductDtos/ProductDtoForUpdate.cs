using Entities.Contracts;

namespace Entities.Dtos.ProductDtos
{
    public record ProductDtoForUpdate : ProductDto, IDtoUpdateItem
    {
    }
}
