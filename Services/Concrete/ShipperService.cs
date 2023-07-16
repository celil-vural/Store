using AutoMapper;
using Entities.Contracts;
using Entities.Dtos.ShipperDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class ShipperService : ServiceBase<Shipper>, IShipperService
    {
        public ShipperService(IShipperManager managerBase, IMapper mapper) : base(managerBase, mapper)
        {
        }

        public override Shipper? GetById(int id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public Shipper? AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public ShipperDtoForUpdate? UpdateWithDtoForUpdate(ShipperDtoForUpdate dtoUpdateItem, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public ShipperDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }
    }
}
