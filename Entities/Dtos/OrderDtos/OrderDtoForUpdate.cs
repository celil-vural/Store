using Entities.Contracts;

namespace Entities.Dtos.OrderDtos
{
    public record OrderDtoForUpdate : OrderDto, IDtoUpdateItem
    {
    }
}
