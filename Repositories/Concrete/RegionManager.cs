using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class RegionManager : RepositoryManagerBase<Region>, IRegionManager
    {
        public RegionManager(IRepositoryBase<Region> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
