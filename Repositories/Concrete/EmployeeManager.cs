using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class EmployeeManager : RepositoryManagerBase<Employee>, IEmployeeManager
    {
        public EmployeeManager(IRepositoryBase<Employee> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
