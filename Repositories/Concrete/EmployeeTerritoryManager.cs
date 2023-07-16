using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class EmployeeTerritoryManager : RepositoryManagerBase<EmployeeTerritory>, IEmployeeTerritoryManager
    {
        public EmployeeTerritoryManager(IRepositoryBase<EmployeeTerritory> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
