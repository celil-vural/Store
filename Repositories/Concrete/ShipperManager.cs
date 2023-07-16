using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class ShipperManager : RepositoryManagerBase<Shipper>, IShipperManager
    {
        public ShipperManager(IRepositoryBase<Shipper> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
