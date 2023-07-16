using Entities.Dtos.ShipperDto;
using Entities.Models;

namespace Services.Contract
{
    public interface IShipperService : IEntityService<Shipper>, IServiceWithDto<Shipper, ShipperDtoForUpdate>
    {
    }
}
