using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class TerritoryManager : RepositoryManagerBase<Territory>, ITerritoryManager
    {
        public TerritoryManager(IRepositoryBase<Territory> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
