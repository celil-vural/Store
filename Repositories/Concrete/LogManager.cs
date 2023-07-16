using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class LogManager : RepositoryManagerBase<Log>, ILogManager
    {
        public LogManager(IRepositoryBase<Log> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
