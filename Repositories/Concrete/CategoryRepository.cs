using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class CategoryRepository : RepositoryManagerBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IRepositoryBase<Category> repositoryBase) : base(repositoryBase)
        {
        }
    }
}
